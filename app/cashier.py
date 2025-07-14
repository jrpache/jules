from flask import Blueprint, render_template, jsonify, request
from flask_login import login_required, current_user
from app import db
from app.models import Product, Invoice, InvoiceItem

bp = Blueprint('cashier', __name__, url_prefix='/cashier')

@bp.route('/')
@login_required
def index():
    return render_template('cashier/index.html')

@bp.route('/get_product/<code>', methods=['GET'])
@login_required
def get_product(code):
    product = Product.query.filter_by(code=code).first()
    if product:
        return jsonify({
            'code': product.code,
            'name': product.name,
            'price': float(product.price),
            'vat_type': product.vat_type
        })
    return jsonify({'error': 'Product not found'}), 404

@bp.route('/checkout', methods=['POST'])
@login_required
def checkout():
    data = request.get_json()
    items = data.get('items')
    if not items:
        return jsonify({'error': 'Cart is empty'}), 400

    total_amount = sum(item['price'] * item['quantity'] for item in items)
    invoice = Invoice(user_id=current_user.id, total_amount=total_amount)
    db.session.add(invoice)
    db.session.flush()

    for item in items:
        product = Product.query.filter_by(code=item['code']).first()
        if product:
            invoice_item = InvoiceItem(
                invoice_id=invoice.id,
                product_id=product.id,
                quantity=item['quantity'],
                unit_price=item['price'],
                vat_type=product.vat_type
            )
            db.session.add(invoice_item)

    db.session.commit()
    return jsonify({'invoice_id': invoice.id})

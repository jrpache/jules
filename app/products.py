from flask import Blueprint, render_template, redirect, url_for, flash
from flask_login import login_required, current_user
from app import db
from app.models import Product
from app.forms import ProductForm

bp = Blueprint('products', __name__, url_prefix='/products')

@bp.route('/')
@login_required
def index():
    products = Product.query.all()
    return render_template('products/index.html', products=products)

@bp.route('/add', methods=['GET', 'POST'])
@login_required
def add_product():
    form = ProductForm()
    if form.validate_on_submit():
        product = Product(
            code=form.code.data,
            name=form.name.data,
            product_type=form.product_type.data,
            price=form.price.data,
            vat_type=form.vat_type.data
        )
        db.session.add(product)
        db.session.commit()
        flash('Product added successfully.')
        return redirect(url_for('products.index'))
    return render_template('products/form.html', form=form, title='Add Product')

@bp.route('/edit/<int:id>', methods=['GET', 'POST'])
@login_required
def edit_product(id):
    product = Product.query.get_or_404(id)
    form = ProductForm(obj=product)
    del form.code # Don't allow editing the code
    if form.validate_on_submit():
        product.name = form.name.data
        product.product_type = form.product_type.data
        product.price = form.price.data
        product.vat_type = form.vat_type.data
        db.session.commit()
        flash('Product updated successfully.')
        return redirect(url_for('products.index'))
    return render_template('products/form.html', form=form, title='Edit Product')

@bp.route('/delete/<int:id>', methods=['POST'])
@login_required
def delete_product(id):
    product = Product.query.get_or_404(id)
    db.session.delete(product)
    db.session.commit()
    flash('Product deleted successfully.')
    return redirect(url_for('products.index'))

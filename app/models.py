from flask_login import UserMixin
from werkzeug.security import generate_password_hash, check_password_hash
from app import db, login_manager

@login_manager.user_loader
def load_user(id):
    return User.query.get(int(id))

class User(UserMixin, db.Model):
    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String(64), index=True, unique=True)
    email = db.Column(db.String(120), index=True, unique=True)
    password_hash = db.Column(db.String(128))
    role = db.Column(db.String(64), default='cajero')  # Roles: cajero, administrador

    def set_password(self, password):
        self.password_hash = generate_password_hash(password)

    def check_password(self, password):
        return check_password_hash(self.password_hash, password)

class Product(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    code = db.Column(db.String(64), index=True, unique=True)
    name = db.Column(db.String(128))
    product_type = db.Column(db.Integer)
    price = db.Column(db.Numeric(10, 2))
    vat_type = db.Column(db.String(10))  # BASICO, MINIMO, EXCENTO

class Invoice(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    user_id = db.Column(db.Integer, db.ForeignKey('user.id'))
    user = db.relationship('User', backref='invoices')
    created_at = db.Column(db.DateTime, server_default=db.func.now())
    total_amount = db.Column(db.Numeric(10, 2))
    items = db.relationship('InvoiceItem', backref='invoice', lazy='dynamic')

class InvoiceItem(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    invoice_id = db.Column(db.Integer, db.ForeignKey('invoice.id'))
    product_id = db.Column(db.Integer, db.ForeignKey('product.id'))
    product = db.relationship('Product')
    quantity = db.Column(db.Integer)
    unit_price = db.Column(db.Numeric(10, 2))
    vat_type = db.Column(db.String(10))

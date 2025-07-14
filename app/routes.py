from flask import Blueprint, render_template
from flask_login import login_required
from . import models

bp = Blueprint('main', __name__)

@bp.route('/')
@bp.route('/index')
@login_required
def index():
    return "¡Hola, mundo!"

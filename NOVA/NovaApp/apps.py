from django.apps import AppConfig


class NovaAppConfig(AppConfig):
    default_auto_field = 'django.db.models.BigAutoField'
    name = 'NOVA.NovaApp'

#UPDATE DB WITH python manage.py makemigrations NovaApp
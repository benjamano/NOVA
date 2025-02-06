from django.urls import path

from NOVA.NovaApp import views as controller    

app_name = "NovaApp"
urlpatterns = [
    path('', controller.index),
]
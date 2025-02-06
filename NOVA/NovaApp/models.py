from django.db import models

#UPDATE DB WITH:
#python manage.py makemigrations NovaApp
#python manage.py sqlmigrate NovaApp [NAME]
#python manage.py migrate

class Task(models.Model):
    title = models.CharField(max_length=200)
    description = models.TextField(blank=True)
    createDate = models.DateTimeField(auto_now_add=True)
    dueDate = models.DateTimeField(null=True, blank=True)
    completed = models.BooleanField(default=False)

    def __str__(self):
        return self.title

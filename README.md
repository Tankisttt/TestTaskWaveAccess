# TestTaskWaveAccess
В базе содержится пользователь WaveAccessEmpl, через которого можно войти без пароля.


Бизнес логику нужно перенести из контроллеров в модель, т.к. контроллеры получились толстыми.
Таблицы с актерами и фильмами были импортированы в базу из различных .csv файлов

Таблицы (many to many) почти не заполнены данными, но смысл LINQ-запросов понятен

Также, БД задеплоена в Azure, если будут проблемы с доступом из .bak

Качество коммитов смотреть смысла нет. Rebase не производился

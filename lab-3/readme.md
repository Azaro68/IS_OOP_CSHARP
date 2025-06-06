<p align="center">
  <img src="https://readme-typing-svg.herokuapp.com?font=Fira+Code&size=30&duration=2000&pause=1000&color=FFFF00&center=true&vCenter=true&width=800&lines=Лабораторная+работа+№3" />
</p>
<p align="center">
  <img src="https://readme-typing-svg.herokuapp.com?font=Fira+Code&size=22&duration=2000&pause=1000&color=00FF00&center=true&vCenter=true&width=800&lines=Система+распределения+сообщений+на+C%23" />
</p>

---

## 🧠 Ключевые концепции

- ✅ Основные принципы ООП
- ✅ SOLID-принципы
- ✅ GRASP-подходы к проектированию
- ✅ Порождающие паттерны (например: **Factory Method**)
- ✅ Структурные паттерны (**Composite**, **Decorator**, **Adapter**)
- ✅ Модульное и мок-тестирование (mocking)

---

## 📡 Описание

В рамках лабораторной реализуется **объектная модель корпоративной системы доставки сообщений**, поддерживающая:

- множество типов адресатов;
- фильтрацию сообщений по уровню важности;
- логгирование доставки;
- возможность группировки и маршрутизации сообщений;
- расширяемость и изоляцию внешних интеграций (мессенджеры, дисплеи).

---

## 🧱 Применяемые паттерны

### 🏭 **Порождающие паттерны**
- **Factory Method** — используется для создания различных типов адресатов без привязки к конкретным классам

### 🧩 **Структурные паттерны**
- **Composite** — реализация групповых адресатов (`GroupRecipient`)
- **Decorator** — логгирование и фильтрация сообщений поверх базовых адресатов
- **Adapter** — для адаптации дисплея и мессенджера к единому интерфейсу доставки сообщений

---

## 🧪 Поддержка Mocking

- Реализации `ILogger`, `IDisplayDriver`, `IMessenger` абстрагированы и могут быть **заменены моками** во время тестирования
- Используются **инъекции зависимостей** для максимальной гибкости
- Тесты покрывают:
  - фильтрацию по важности
  - повторные попытки отметки прочитанного сообщения
  - отправку в изолированные внешние каналы
  - корректность логгирования

---

## 🧰 Технологии

- Язык: **C#**
- Пакеты: [`Crayon`](https://github.com/riezebosch/Crayon) для окраски вывода
- Тестирование: **xUnit**, **MoQ**
- Принципы: **SOLID**, **GRASP**, **TDD**

---

## ✅ Особенности реализации

- Сообщения имеют уровень важности и статусы (прочитано/не прочитано)
- Пользователь может отслеживать и изменять статус сообщений
- Адресаты могут быть индивидуальными (User, Messenger, Display) или групповыми
- Логика логгирования и фильтрации отделена от бизнес-ядра с помощью декораторов
- Внешние интеграции реализованы как изолированные компоненты
- Возможность тестирования без побочных эффектов (ввод/вывод изолирован)

---

## 🧪 Примеры тест-кейсов

- ✅ Пользователь получает сообщение в статусе "не прочитано"
- ✅ Успешная смена статуса на "прочитано"
- ❌ Повторная попытка отметить уже прочитанное сообщение → ошибка
- ✅ Фильтр блокирует сообщение с низким приоритетом (через mock)
- ✅ Логгирование срабатывает при получении (через mock)
- ✅ Отправка в мессенджер приводит к ожидаемому результату (через mock)
- ✅ Дублирование адресатов обрабатывается корректно

---

## 🎯 Цель

Демонстрация комплексного подхода к проектированию, основанного на:

- **объектно-ориентированной архитектуре**
- **паттернах проектирования**
- **разделении ответственности и тестируемости компонентов**

# «Массивы, интерфейсы IComparable<T> и IEnumerator<T>, оператор yield»

### Цели работы:
- [x] Научиться синтаксису и принципам работы с массивами средствами языка C#.
- [x] Научиться реализовывать интерфейсы IComparable<T> и IEnumerator<T>.
- [x] Получить практические навыки работы с оператором yield.

### Задание№1
Создайте класс `MyMatrix`, представляющий матрицу `m` на `n`.

Создайте конструктор, принимающий число строк и столбцов, заполняющий матрицу случайными числами в диапазоне, который пользователь вводит при запуске программы.

Определите операторы сложения, вычитания и умножения  матриц, а также умножения и деления матрицы на число.

Создайте пользовательский индексатор матрицы для доступа к элементам матрицы по номеру строки и столбца.

### Задание№2
Создайте класс Car с тремя авто-свойствами: Name, ProductionYear и MaxSpeed, соответствующими названию, году выпуска и максимальной скорости соответственно.

Создайте класс CarComparer, наследуемый от IComparer<Car> и реализуйте метод Compare таким образом, чтобы можно было сортировать массив элементов Car по названию, году выпуска или максимальной скорости по выбору.

Создайте массив элементов Car и продемонстрируйте сортировку различными способами.

### Задание№3
Используйте класс `Ca`r из задания №2, на его основе создайте класс `CarCatalor`, содержащий массив элементов типа `Car`. 

Для класса `CarCatalog` реализуйте возможность итерации по элементам массива `Car` с помощью оператора `foreach` различными способами: 

Прямой проход с первого элемента до последнего.

Обратный проход от последнего к первому.

Проход по элементам массива с фильтром по году выпуска.

Проход по элементам массива с фильтром по максимальной скорости.


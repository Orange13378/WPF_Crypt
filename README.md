Курсовая работа Аскерли Муслим сделана на wpf (ожидаемый результат)

Программа шифрования/дешифрования текста с помощью шифра Виженера (ключ для тхт-файла Result v5 "скорпион").

Программа состоит из 3 TextBox'ов. Первый для ввода ключа который можно в любой момент изменить, второй для самого текста который нужно шифровать/дешифровать (с помошью CheckBox'а (Ввод с клавиатуры) можно самому написать свой текст, нужно всего лишь активировать его, и при отключении текст опять снова станет неизменяемым пользователю), 
так же включен функционал открытия txt-файла, текст которого будет представлен во втором TextBox'е. И третий CheckBox в котором будет выведен результат работы нашей программы. 

Так же в программе имеются 5 кнопок:

1 
Open File с помощью которой пользователь может открыть txt-файл который находится у него на компьютере.

2 и 3 
Кнопки Encode и Decode которые работают только в том случае, если имеется тест для преобразования и написан ключ. Сами кнопки шифруют и дешифруют тест соответственно и выводят результат на экран.

4 и 5 
Кнопки Save Encode и Save Decode которые сохраняют результат зашифрованного или расшифрованного кода куда пользователь сам захочет на компьютере (кнопка Save Encode работает в случае если результат программы является заштфрованным, а кнопка Save Decode если результат программы является расшифрованным).

На каждой кнопке используется собственноручно написанный метод, который проверятся Unit Test'ом (Проверка шифратора дешифратора, проверка пути файл и проверка сохранения без ошибок (выбор куда сохранять txt-файл, проверятся сохранение в него пустой строки)).
// LIST Status = expected, taken, formed, deposited
VAR quest_done = false
VAR quest_close = false
VAR checkpoint = false
VAR state = 0

//=== START ===//
-> begin

=== begin ===
* {state != 3} -> quest
* {state == 3} -> default

=== default ===
Спасибо что помог тогда. Этим летом хороший вырос урожай.
-> END

=== quest ===
* {state == 0} -> quest.start
* {state != 0} -> quest.performed
= start
    Эй, Хиро! Ты не мог бы помочь старику?
    * [Что случилось?] -> description
= description
    Чёртовы логи залезли в мой огород и не дают мне проходу.
    * [Почему они полезли тебе в огород?] -> description2
= description2
    Незнаю. Видимо им понравилась хорошо удобренная тамошняя почва.
    В любом случае, ты не мог бы с этим помочь?
    * [Хорошо, я с ними разберусь.] -> agreement
= agreement
    ~ state = 1
    Спасибо тебе, за мной не останется. Дам тебе за это кучу яблок. 
    -> END
= performed
    Ну как там дела с этими паразитами?
    * {state != 2} [Ещё нет, пока не разорбрался.]
        Тогда скажешь как закончишь. -> END
    * {state == 2} [Я всё сделал!]
        ~ state = 3
        Спасибо тебе. Вот твои свежие яблочки.
        -> END

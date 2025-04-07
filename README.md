1. Na czym polega wzorzec Prototyp?
Wzorzec Prototyp polega na tworzeniu nowych obiektów poprzez klonowanie już istniejących obiektów (prototypów) zamiast ich instancjonowania od zera za pomocą new.

Obiekt-prototyp udostępnia metodę (np. Clone()), która zwraca kopię samego siebie — może to być:

płytka kopia (shallow copy) – kopiowane są tylko wartości pól, a referencje pozostają te same,

głęboka kopia (deep copy) – kopiowane są również wszystkie obiekty zależne (rekurencyjnie).

2. Jaki problem rozwiązuje?
Wzorzec Prototyp rozwiązuje problem kosztownego lub skomplikowanego tworzenia obiektów.

Przykładowe problemy:

Obiekty mają złożoną strukturę i wiele parametrów konfiguracyjnych.

Tworzenie nowych instancji jest czasochłonne (np. wymagają pobierania danych z sieci, przetwarzania plików itp.).

Potrzeba tworzenia wielu podobnych obiektów — zamiast pisać kod inicjalizujący, kopiujesz gotowy egzemplarz.

Chcesz dynamicznie tworzyć instancje obiektów bez zależności od ich konkretnych klas (np. w edytorze poziomów gry, gdzie tworzysz kopie przeciwników, budynków itp.).

3. ⚖Zalety i wady wzorca Prototyp
✅ Zalety:
 Unikanie kosztownego tworzenia	Tworzenie kopii jest szybsze niż tworzenie nowych obiektów od zera.
 Elastyczność	Możliwość klonowania obiektów bez znajomości ich konkretnego typu.
 Łatwość konfiguracji	Możesz przygotować "szablony" obiektów i kopiować je w zależności od potrzeb.
 Praktyczne zastosowanie w grach i edytorach	Idealne do kopiowania jednostek, przeciwników, obiektów UI itp.
❌ Wady:
 Złożoność głębokiego kopiowania	Trudne w implementacji, gdy obiekt ma zagnieżdżone obiekty i zależności.
 Ryzyko błędów	Łatwo o błędy, jeśli zapomnisz skopiować jakiegoś pola (szczególnie przy deep copy).
 Trudności z debugowaniem	Błędy związane z kopiowaniem mogą być trudne do wykrycia.
 Potrzeba implementacji Clone w wielu klasach	Może prowadzić do powielania kodu lub naruszenia zasady pojedynczej odpowiedzialności .

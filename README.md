# FluentCodingRewrite
Redo fluent coding, cleaning unused stuff, consolidate functionalities and namings across types and extension, hiding most extension into internal classes

### Extensions for generic types that allows to be combined using a 'dotted' syntax allowing a fluent development:
* **Do<T>**: Apply any Action<T> using a T object then return the object
* **Equals**: Comparability between a T object and an Array of K objects
* **Map<T,K>**: Apply a Func<T,K> to a T object to return a K object 
* **Or<T>**: Choose between a T object or a T substitute if object is null or do not meet some requirements
* Misc:
  * Null checks for a T object
  * Convert a T object into a Task<T>

### FluentTypes that allow to implement switch and similar concepts using fluent sintax, or that introduce functional progamming (FP) concepts:
* **Optional**: introduce the Some/None concept from FP and implement: Do, Map, Match, On, Or, To, Bind functionalities for this type
* **Outcome**: introduce the Left/Right binary development concept from FP and implement: Do, Map, Match, On, To, Bind functionalities for this type
* **SwitchMap**: introduce a switch/guard object to fluently write a switch case and implement: Match
* **TryCatch**: introduce a try object to fluently write a try/catch case and implement: Match, On, To
* **When**: introduce a When object to fluenty write a if or if/else case:


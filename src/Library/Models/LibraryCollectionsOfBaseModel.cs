using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace Library.Models;

public record LibraryBaseModel(string Code, string Name, LibraryBaseModelSubmodel Submodel);

public record LibraryBaseModelSubmodel(string Duop);
public record LibraryCollectionsOfBaseModel(
    // IEnumerable
    IEnumerable<LibraryBaseModel> IEnumerableValues,

    // ICollection
    ICollection<LibraryBaseModel> ICollectionValues,

    // IReadOnlyCollection
    IReadOnlyCollection<LibraryBaseModel> IReadOnlyCollectionValues,

    // IDictionary
    IDictionary<LibraryBaseModel, LibraryBaseModel> IDictionaryValues,

    // IReadOnlyDictionary
    IReadOnlyDictionary<LibraryBaseModel, LibraryBaseModel> IReadOnlyDictionaryValues,

    // ISet
    ISet<LibraryBaseModel> ISetValues,

    // List
    List<LibraryBaseModel> ListValues,

    // HashSet
    HashSet<LibraryBaseModel> HashSetValues,

    // Queue
    Queue<LibraryBaseModel> QueueValues,

    // Stack
    Stack<LibraryBaseModel> StackValues,

    // Concurrent Collections
    ConcurrentBag<LibraryBaseModel> ConcurrentBagValues,
    ConcurrentQueue<LibraryBaseModel> ConcurrentQueueValues,
    ConcurrentStack<LibraryBaseModel> ConcurrentStackValues,
    ConcurrentDictionary<LibraryBaseModel, LibraryBaseModel> ConcurrentDictionaryValues,

    // Immutable Collections
    ImmutableArray<LibraryBaseModel> ImmutableArrayValues,
    ImmutableList<LibraryBaseModel> ImmutableListValues,
    ImmutableDictionary<LibraryBaseModel, LibraryBaseModel> ImmutableDictionaryValues,
    ImmutableHashSet<LibraryBaseModel> ImmutableHashSetValues,
    ImmutableQueue<LibraryBaseModel> ImmutableQueueValues,
    ImmutableStack<LibraryBaseModel> ImmutableStackValues,

    // ObservableCollection
    ObservableCollection<LibraryBaseModel> ObservableCollectionValues
);
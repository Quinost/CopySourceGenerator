﻿using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace Library.Models;
public record LibraryCollectionsOfBasicTypesModel(
    // IEnumerable
    IEnumerable<int> IEnumerableIntValues,
    IEnumerable<long> IEnumerableLongValues,
    IEnumerable<float> IEnumerableFloatValues,
    IEnumerable<double> IEnumerableDoubleValues,
    IEnumerable<decimal> IEnumerableDecimalValues,
    IEnumerable<bool> IEnumerableBoolValues,
    IEnumerable<char> IEnumerableCharValues,
    IEnumerable<string> IEnumerableStringValues,
    IEnumerable<DateTime> IEnumerableDateTimeValues,

    // ICollection
    ICollection<int> ICollectionIntValues,
    ICollection<long> ICollectionLongValues,
    ICollection<float> ICollectionFloatValues,
    ICollection<double> ICollectionDoubleValues,
    ICollection<decimal> ICollectionDecimalValues,
    ICollection<bool> ICollectionBoolValues,
    ICollection<char> ICollectionCharValues,
    ICollection<string> ICollectionStringValues,
    ICollection<DateTime> ICollectionDateTimeValues,

    // IReadOnlyCollection
    IReadOnlyCollection<int> IReadOnlyCollectionIntValues,
    IReadOnlyCollection<long> IReadOnlyCollectionLongValues,
    IReadOnlyCollection<float> IReadOnlyCollectionFloatValues,
    IReadOnlyCollection<double> IReadOnlyCollectionDoubleValues,
    IReadOnlyCollection<decimal> IReadOnlyCollectionDecimalValues,
    IReadOnlyCollection<bool> IReadOnlyCollectionBoolValues,
    IReadOnlyCollection<char> IReadOnlyCollectionCharValues,
    IReadOnlyCollection<string> IReadOnlyCollectionStringValues,
    IReadOnlyCollection<DateTime> IReadOnlyCollectionDateTimeValues,

    // IDictionary
    IDictionary<int, int> IDictionaryIntValues,
    IDictionary<long, long> IDictionaryLongValues,
    IDictionary<float, float> IDictionaryFloatValues,
    IDictionary<double, double> IDictionaryDoubleValues,
    IDictionary<decimal, decimal> IDictionaryDecimalValues,
    IDictionary<bool, bool> IDictionaryBoolValues,
    IDictionary<char, char> IDictionaryCharValues,
    IDictionary<string, string> IDictionaryStringValues,
    IDictionary<DateTime, DateTime> IDictionaryDateTimeValues,

    // IReadOnlyDictionary
    IReadOnlyDictionary<int, int> IReadOnlyDictionaryIntValues,
    IReadOnlyDictionary<long, long> IReadOnlyDictionaryLongValues,
    IReadOnlyDictionary<float, float> IReadOnlyDictionaryFloatValues,
    IReadOnlyDictionary<double, double> IReadOnlyDictionaryDoubleValues,
    IReadOnlyDictionary<decimal, decimal> IReadOnlyDictionaryDecimalValues,
    IReadOnlyDictionary<bool, bool> IReadOnlyDictionaryBoolValues,
    IReadOnlyDictionary<char, char> IReadOnlyDictionaryCharValues,
    IReadOnlyDictionary<string, string> IReadOnlyDictionaryStringValues,
    IReadOnlyDictionary<DateTime, DateTime> IReadOnlyDictionaryDateTimeValues,

    // ISet
    ISet<int> ISetIntValues,
    ISet<long> ISetLongValues,
    ISet<float> ISetFloatValues,
    ISet<double> ISetDoubleValues,
    ISet<decimal> ISetDecimalValues,
    ISet<bool> ISetBoolValues,
    ISet<char> ISetCharValues,
    ISet<string> ISetStringValues,
    ISet<DateTime> ISetDateTimeValues,

    // List
    List<int> ListIntValues,
    List<long> ListLongValues,
    List<float> ListFloatValues,
    List<double> ListDoubleValues,
    List<decimal> ListDecimalValues,
    List<bool> ListBoolValues,
    List<char> ListCharValues,
    List<string> ListStringValues,
    List<DateTime> ListDateTimeValues,

    // HashSet
    HashSet<int> HashSetIntValues,
    HashSet<long> HashSetLongValues,
    HashSet<float> HashSetFloatValues,
    HashSet<double> HashSetDoubleValues,
    HashSet<decimal> HashSetDecimalValues,
    HashSet<bool> HashSetBoolValues,
    HashSet<char> HashSetCharValues,
    HashSet<string> HashSetStringValues,
    HashSet<DateTime> HashSetDateTimeValues,

    // Queue
    Queue<int> QueueIntValues,
    Queue<long> QueueLongValues,
    Queue<float> QueueFloatValues,
    Queue<double> QueueDoubleValues,
    Queue<decimal> QueueDecimalValues,
    Queue<bool> QueueBoolValues,
    Queue<char> QueueCharValues,
    Queue<string> QueueStringValues,
    Queue<DateTime> QueueDateTimeValues,

    // Stack
    Stack<int> StackIntValues,
    Stack<long> StackLongValues,
    Stack<float> StackFloatValues,
    Stack<double> StackDoubleValues,
    Stack<decimal> StackDecimalValues,
    Stack<bool> StackBoolValues,
    Stack<char> StackCharValues,
    Stack<string> StackStringValues,
    Stack<DateTime> StackDateTimeValues,

    // Concurrent Collections
    ConcurrentBag<int> ConcurrentBagIntValues,
    ConcurrentBag<long> ConcurrentBagLongValues,
    ConcurrentBag<float> ConcurrentBagFloatValues,
    ConcurrentBag<double> ConcurrentBagDoubleValues,
    ConcurrentBag<decimal> ConcurrentBagDecimalValues,
    ConcurrentBag<bool> ConcurrentBagBoolValues,
    ConcurrentBag<char> ConcurrentBagCharValues,
    ConcurrentBag<string> ConcurrentBagStringValues,
    ConcurrentBag<DateTime> ConcurrentBagDateTimeValues,

    ConcurrentQueue<int> ConcurrentQueueIntValues,
    ConcurrentQueue<long> ConcurrentQueueLongValues,
    ConcurrentQueue<float> ConcurrentQueueFloatValues,
    ConcurrentQueue<double> ConcurrentQueueDoubleValues,
    ConcurrentQueue<decimal> ConcurrentQueueDecimalValues,
    ConcurrentQueue<bool> ConcurrentQueueBoolValues,
    ConcurrentQueue<char> ConcurrentQueueCharValues,
    ConcurrentQueue<string> ConcurrentQueueStringValues,
    ConcurrentQueue<DateTime> ConcurrentQueueDateTimeValues,

    ConcurrentStack<int> ConcurrentStackIntValues,
    ConcurrentStack<long> ConcurrentStackLongValues,
    ConcurrentStack<float> ConcurrentStackFloatValues,
    ConcurrentStack<double> ConcurrentStackDoubleValues,
    ConcurrentStack<decimal> ConcurrentStackDecimalValues,
    ConcurrentStack<bool> ConcurrentStackBoolValues,
    ConcurrentStack<char> ConcurrentStackCharValues,
    ConcurrentStack<string> ConcurrentStackStringValues,
    ConcurrentStack<DateTime> ConcurrentStackDateTimeValues,

    ConcurrentDictionary<int, int> ConcurrentDictionaryIntValues,
    ConcurrentDictionary<long, long> ConcurrentDictionaryLongValues,
    ConcurrentDictionary<float, float> ConcurrentDictionaryFloatValues,
    ConcurrentDictionary<double, double> ConcurrentDictionaryDoubleValues,
    ConcurrentDictionary<decimal, decimal> ConcurrentDictionaryDecimalValues,
    ConcurrentDictionary<bool, bool> ConcurrentDictionaryBoolValues,
    ConcurrentDictionary<char, char> ConcurrentDictionaryCharValues,
    ConcurrentDictionary<string, string> ConcurrentDictionaryStringValues,
    ConcurrentDictionary<DateTime, DateTime> ConcurrentDictionaryDateTimeValues,

    // Immutable Collections
    ImmutableArray<int> ImmutableArrayIntValues,
    ImmutableArray<long> ImmutableArrayLongValues,
    ImmutableArray<float> ImmutableArrayFloatValues,
    ImmutableArray<double> ImmutableArrayDoubleValues,
    ImmutableArray<decimal> ImmutableArrayDecimalValues,
    ImmutableArray<bool> ImmutableArrayBoolValues,
    ImmutableArray<char> ImmutableArrayCharValues,
    ImmutableArray<string> ImmutableArrayStringValues,
    ImmutableArray<DateTime> ImmutableArrayDateTimeValues,

    ImmutableList<int> ImmutableListIntValues,
    ImmutableList<long> ImmutableListLongValues,
    ImmutableList<float> ImmutableListFloatValues,
    ImmutableList<double> ImmutableListDoubleValues,
    ImmutableList<decimal> ImmutableListDecimalValues,
    ImmutableList<bool> ImmutableListBoolValues,
    ImmutableList<char> ImmutableListCharValues,
    ImmutableList<string> ImmutableListStringValues,
    ImmutableList<DateTime> ImmutableListDateTimeValues,

    ImmutableDictionary<int, int> ImmutableDictionaryIntValues,
    ImmutableDictionary<long, long> ImmutableDictionaryLongValues,
    ImmutableDictionary<float, float> ImmutableDictionaryFloatValues,
    ImmutableDictionary<double, double> ImmutableDictionaryDoubleValues,
    ImmutableDictionary<decimal, decimal> ImmutableDictionaryDecimalValues,
    ImmutableDictionary<bool, bool> ImmutableDictionaryBoolValues,
    ImmutableDictionary<char, char> ImmutableDictionaryCharValues,
    ImmutableDictionary<string, string> ImmutableDictionaryStringValues,
    ImmutableDictionary<DateTime, DateTime> ImmutableDictionaryDateTimeValues,

    ImmutableHashSet<int> ImmutableHashSetIntValues,
    ImmutableHashSet<long> ImmutableHashSetLongValues,
    ImmutableHashSet<float> ImmutableHashSetFloatValues,
    ImmutableHashSet<double> ImmutableHashSetDoubleValues,
    ImmutableHashSet<decimal> ImmutableHashSetDecimalValues,
    ImmutableHashSet<bool> ImmutableHashSetBoolValues,
    ImmutableHashSet<char> ImmutableHashSetCharValues,
    ImmutableHashSet<string> ImmutableHashSetStringValues,
    ImmutableHashSet<DateTime> ImmutableHashSetDateTimeValues,

    ImmutableQueue<int> ImmutableQueueIntValues,
    ImmutableQueue<long> ImmutableQueueLongValues,
    ImmutableQueue<float> ImmutableQueueFloatValues,
    ImmutableQueue<double> ImmutableQueueDoubleValues,
    ImmutableQueue<decimal> ImmutableQueueDecimalValues,
    ImmutableQueue<bool> ImmutableQueueBoolValues,
    ImmutableQueue<char> ImmutableQueueCharValues,
    ImmutableQueue<string> ImmutableQueueStringValues,
    ImmutableQueue<DateTime> ImmutableQueueDateTimeValues,

    ImmutableStack<int> ImmutableStackIntValues,
    ImmutableStack<long> ImmutableStackLongValues,
    ImmutableStack<float> ImmutableStackFloatValues,
    ImmutableStack<double> ImmutableStackDoubleValues,
    ImmutableStack<decimal> ImmutableStackDecimalValues,
    ImmutableStack<bool> ImmutableStackBoolValues,
    ImmutableStack<char> ImmutableStackCharValues,
    ImmutableStack<string> ImmutableStackStringValues,
    ImmutableStack<DateTime> ImmutableStackDateTimeValues,

    // ObservableCollection
    ObservableCollection<int> ObservableCollectionIntValues,
    ObservableCollection<long> ObservableCollectionLongValues,
    ObservableCollection<float> ObservableCollectionFloatValues,
    ObservableCollection<double> ObservableCollectionDoubleValues,
    ObservableCollection<decimal> ObservableCollectionDecimalValues,
    ObservableCollection<bool> ObservableCollectionBoolValues,
    ObservableCollection<char> ObservableCollectionCharValues,
    ObservableCollection<string> ObservableCollectionStringValues,
    ObservableCollection<DateTime> ObservableCollectionDateTimeValues
);
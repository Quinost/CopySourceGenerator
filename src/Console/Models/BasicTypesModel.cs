using Console.Models;

namespace Library.Models;

public record BasicTypesModel(
    ICollection<EnumModel> StringCollection,
    LibraryCollectionsOfBaseModel LibraryBasicTypesModel123123, 
    LibraryCollectionsOfBasicTypesModel LibraryBasicTypesModel123124,
    LibraryBasicTypesModel LibraryBasicTypesModel123125,
    int IntValue,
    long LongValue,
    float FloatValue,
    double DoubleValue,
    decimal DecimalValue,
    bool BoolValue,
    char CharValue,
    string StringValue,
    DateTime DateTimeValue
);
namespace Library.Models;

public record LibraryBasicTypesModel(
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
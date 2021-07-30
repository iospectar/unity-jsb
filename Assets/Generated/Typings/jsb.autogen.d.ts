declare module "System" {
    import * as jsb from "jsb";
    class Byte extends Object {
        CompareTo(value: Object): number
        CompareTo(value: jsb.byte): number
        Equals(obj: Object): boolean
        Equals(obj: jsb.byte): boolean
        GetHashCode(): number
        toString(format: string, provider: any): string
        toString(format: string): string
        toString(provider: any): string
        toString(): string
        GetTypeCode(): any
        static Parse(s: string, style: any, provider: any): jsb.byte
        static Parse(s: string, style: any): jsb.byte
        static Parse(s: string, provider: any): jsb.byte
        static Parse(s: string): jsb.byte
        static TryParse(s: string, style: any, provider: any, result: jsb.Out<jsb.byte>): boolean
        static TryParse(s: string, result: jsb.Out<jsb.byte>): boolean
        protected constructor()
        static readonly MaxValue: jsb.byte
        static readonly MinValue: jsb.byte
    }
}
declare module "System" {
    import * as jsb from "jsb";
    class SByte extends Object {
        CompareTo(obj: Object): number
        CompareTo(value: number): number
        Equals(obj: Object): boolean
        Equals(obj: number): boolean
        GetHashCode(): number
        toString(format: string, provider: any): string
        toString(provider: any): string
        toString(format: string): string
        toString(): string
        GetTypeCode(): any
        static Parse(s: string, style: any, provider: any): number
        static Parse(s: string, style: any): number
        static Parse(s: string, provider: any): number
        static Parse(s: string): number
        static TryParse(s: string, style: any, provider: any, result: jsb.Out<number>): boolean
        static TryParse(s: string, result: jsb.Out<number>): boolean
        protected constructor()
        static readonly MaxValue: number
        static readonly MinValue: number
    }
}
declare module "System" {
    import * as jsb from "jsb";
    class Single extends Object {
        CompareTo(value: Object): number
        CompareTo(value: number): number
        Equals(obj: Object): boolean
        Equals(obj: number): boolean
        GetHashCode(): number
        toString(format: string, provider: any): string
        toString(provider: any): string
        toString(format: string): string
        toString(): string
        GetTypeCode(): any
        static IsInfinity(f: number): boolean
        static IsPositiveInfinity(f: number): boolean
        static IsNegativeInfinity(f: number): boolean
        static IsNaN(f: number): boolean
        static op_Inequality(left: number, right: number): boolean
        static op_GreaterThan(left: number, right: number): boolean
        static op_LessThanOrEqual(left: number, right: number): boolean
        static op_GreaterThanOrEqual(left: number, right: number): boolean
        static Parse(s: string, style: any, provider: any): number
        static Parse(s: string, style: any): number
        static Parse(s: string, provider: any): number
        static Parse(s: string): number
        static TryParse(s: string, style: any, provider: any, result: jsb.Out<number>): boolean
        static TryParse(s: string, result: jsb.Out<number>): boolean
        // js_op_overloading: static ==(left: number, right: number): boolean
        // js_op_overloading: static <(left: number, right: number): boolean
        protected constructor()
        static readonly MinValue: number
        static readonly Epsilon: number
        static readonly MaxValue: number
        static readonly PositiveInfinity: number
        static readonly NegativeInfinity: number
        static readonly NaN: number
    }
}
declare module "System" {
    import * as jsb from "jsb";
    class Double extends Object {
        CompareTo(value: Object): number
        CompareTo(value: number): number
        Equals(obj: Object): boolean
        Equals(obj: number): boolean
        GetHashCode(): number
        toString(format: string, provider: any): string
        toString(format: string): string
        toString(provider: any): string
        toString(): string
        GetTypeCode(): any
        static IsInfinity(d: number): boolean
        static IsPositiveInfinity(d: number): boolean
        static IsNegativeInfinity(d: number): boolean
        static IsNaN(d: number): boolean
        static op_Inequality(left: number, right: number): boolean
        static op_GreaterThan(left: number, right: number): boolean
        static op_LessThanOrEqual(left: number, right: number): boolean
        static op_GreaterThanOrEqual(left: number, right: number): boolean
        static Parse(s: string, style: any, provider: any): number
        static Parse(s: string, style: any): number
        static Parse(s: string, provider: any): number
        static Parse(s: string): number
        static TryParse(s: string, style: any, provider: any, result: jsb.Out<number>): boolean
        static TryParse(s: string, result: jsb.Out<number>): boolean
        // js_op_overloading: static ==(left: number, right: number): boolean
        // js_op_overloading: static <(left: number, right: number): boolean
        protected constructor()
        static readonly MinValue: number
        static readonly MaxValue: number
        static readonly Epsilon: number
        static readonly NegativeInfinity: number
        static readonly PositiveInfinity: number
        static readonly NaN: number
    }
}
declare module "System" {
    import * as jsb from "jsb";
    class String extends Object {
        constructor(value: Array<string>, startIndex: number, length: number)
        constructor(c: string, count: number)
        constructor(value: Array<string>)
        Equals(value: string, comparisonType: any): boolean
        Equals(obj: Object): boolean
        Equals(value: string): boolean
        CopyTo(sourceIndex: number, destination: Array<string>, destinationIndex: number, count: number): void
        ToCharArray(startIndex: number, length: number): Array<string>
        ToCharArray(): Array<string>
        GetHashCode(): number
        Split(separator: Array<string>, count: number, options: any): Array<string>
        Split(separator: Array<string>, count: number, options: any): Array<string>
        Split(separator: Array<string>, count: number): Array<string>
        Split(separator: Array<string>, options: any): Array<string>
        Split(separator: Array<string>, options: any): Array<string>
        Split(...separator: string[]): Array<string>
        Substring(startIndex: number, length: number): string
        Substring(startIndex: number): string
        Trim(): string
        Trim(...trimChars: string[]): string
        TrimStart(...trimChars: string[]): string
        TrimEnd(...trimChars: string[]): string
        IsNormalized(normalizationForm: any): boolean
        IsNormalized(): boolean
        Normalize(normalizationForm: any): string
        Normalize(): string
        CompareTo(value: Object): number
        CompareTo(strB: string): number
        Contains(value: string): boolean
        EndsWith(value: string, ignoreCase: boolean, culture: any): boolean
        EndsWith(value: string, comparisonType: any): boolean
        EndsWith(value: string): boolean
        IndexOf(value: string, startIndex: number, count: number, comparisonType: any): number
        IndexOf(value: string, startIndex: number, count: number): number
        IndexOf(value: string, startIndex: number, comparisonType: any): number
        IndexOf(value: string, startIndex: number, count: number): number
        IndexOf(value: string, startIndex: number): number
        IndexOf(value: string, startIndex: number): number
        IndexOf(value: string, comparisonType: any): number
        IndexOf(value: string): number
        IndexOf(value: string): number
        IndexOfAny(anyOf: Array<string>, startIndex: number, count: number): number
        IndexOfAny(anyOf: Array<string>, startIndex: number): number
        IndexOfAny(anyOf: Array<string>): number
        LastIndexOf(value: string, startIndex: number, count: number, comparisonType: any): number
        LastIndexOf(value: string, startIndex: number, count: number): number
        LastIndexOf(value: string, startIndex: number, comparisonType: any): number
        LastIndexOf(value: string, startIndex: number, count: number): number
        LastIndexOf(value: string, startIndex: number): number
        LastIndexOf(value: string, startIndex: number): number
        LastIndexOf(value: string, comparisonType: any): number
        LastIndexOf(value: string): number
        LastIndexOf(value: string): number
        LastIndexOfAny(anyOf: Array<string>, startIndex: number, count: number): number
        LastIndexOfAny(anyOf: Array<string>, startIndex: number): number
        LastIndexOfAny(anyOf: Array<string>): number
        PadLeft(totalWidth: number, paddingChar: string): string
        PadLeft(totalWidth: number): string
        PadRight(totalWidth: number, paddingChar: string): string
        PadRight(totalWidth: number): string
        StartsWith(value: string, ignoreCase: boolean, culture: any): boolean
        StartsWith(value: string, comparisonType: any): boolean
        StartsWith(value: string): boolean
        ToLower(culture: any): string
        ToLower(): string
        ToLowerInvariant(): string
        ToUpper(culture: any): string
        ToUpper(): string
        ToUpperInvariant(): string
        toString(provider: any): string
        toString(): string
        Clone(): Object
        Insert(startIndex: number, value: string): string
        Replace(oldChar: string, newChar: string): string
        Replace(oldValue: string, newValue: string): string
        Remove(startIndex: number, count: number): string
        Remove(startIndex: number): string
        GetTypeCode(): any
        GetEnumerator(): any
        static Join(separator: string, value: Array<string>, startIndex: number, count: number): string
        static Join(separator: string, values: any): string
        static Join(separator: string, ...value: string[]): string
        static Join(separator: string, ...values: Object[]): string
        static Equals(a: string | Object, b: string | Object, comparisonType: any): boolean
        static Equals(a: string | Object, b: string | Object): boolean
        static op_Inequality(a: string, b: string): boolean
        static IsNullOrEmpty(value: string): boolean
        static IsNullOrWhiteSpace(value: string): boolean
        static Compare(strA: string, indexA: number, strB: string, indexB: number, length: number, ignoreCase: boolean, culture: any): number
        static Compare(strA: string, indexA: number, strB: string, indexB: number, length: number, culture: any, options: any): number
        static Compare(strA: string, indexA: number, strB: string, indexB: number, length: number, ignoreCase: boolean): number
        static Compare(strA: string, indexA: number, strB: string, indexB: number, length: number, comparisonType: any): number
        static Compare(strA: string, indexA: number, strB: string, indexB: number, length: number): number
        static Compare(strA: string, strB: string, culture: any, options: any): number
        static Compare(strA: string, strB: string, ignoreCase: boolean, culture: any): number
        static Compare(strA: string, strB: string, ignoreCase: boolean): number
        static Compare(strA: string, strB: string, comparisonType: any): number
        static Compare(strA: string, strB: string): number
        static CompareOrdinal(strA: string, indexA: number, strB: string, indexB: number, length: number): number
        static CompareOrdinal(strA: string, strB: string): number
        static Format(provider: any, format: string, arg0: Object, arg1: Object, arg2: Object): string
        static Format(format: string, arg0: Object, arg1: Object, arg2: Object): string
        static Format(provider: any, format: string, arg0: Object, arg1: Object): string
        static Format(format: string, arg0: Object, arg1: Object): string
        static Format(provider: any, format: string, arg0: Object): string
        static Format(format: string, arg0: Object): string
        static Format(provider: any, format: string, ...args: Object[]): string
        static Format(format: string, ...args: Object[]): string
        static Copy(str: string): string
        static Concat(arg0: Object, arg1: Object, arg2: Object, arg3: Object): string
        static Concat(str0: string, str1: string, str2: string, str3: string): string
        static Concat(arg0: Object, arg1: Object, arg2: Object): string
        static Concat(str0: string, str1: string, str2: string): string
        static Concat(arg0: Object, arg1: Object): string
        static Concat(str0: string, str1: string): string
        static Concat(arg0: Object): string
        static Concat(values: any): string
        static Concat(...args: Object[]): string
        static Concat(...values: string[]): string
        static Intern(str: string): string
        static IsInterned(str: string): string
        // js_op_overloading: static ==(a: string, b: string): boolean
        readonly Length: number
        static readonly Empty: string
    }
}
declare module "System" {
    import * as jsb from "jsb";
    class Int32 extends Object {
        CompareTo(value: Object): number
        CompareTo(value: number): number
        Equals(obj: Object): boolean
        Equals(obj: number): boolean
        GetHashCode(): number
        toString(format: string, provider: any): string
        toString(format: string): string
        toString(provider: any): string
        toString(): string
        GetTypeCode(): any
        static Parse(s: string, style: any, provider: any): number
        static Parse(s: string, style: any): number
        static Parse(s: string, provider: any): number
        static Parse(s: string): number
        static TryParse(s: string, style: any, provider: any, result: jsb.Out<number>): boolean
        static TryParse(s: string, result: jsb.Out<number>): boolean
        protected constructor()
        static readonly MaxValue: number
        static readonly MinValue: number
    }
}
declare module "System" {
    import * as jsb from "jsb";
    class UInt32 extends Object {
        CompareTo(value: Object): number
        CompareTo(value: number): number
        Equals(obj: Object): boolean
        Equals(obj: number): boolean
        GetHashCode(): number
        toString(format: string, provider: any): string
        toString(provider: any): string
        toString(format: string): string
        toString(): string
        GetTypeCode(): any
        static Parse(s: string, style: any, provider: any): number
        static Parse(s: string, style: any): number
        static Parse(s: string, provider: any): number
        static Parse(s: string): number
        static TryParse(s: string, style: any, provider: any, result: jsb.Out<number>): boolean
        static TryParse(s: string, result: jsb.Out<number>): boolean
        protected constructor()
        static readonly MaxValue: number
        static readonly MinValue: number
    }
}
declare module "System" {
    import * as jsb from "jsb";
    class Int16 extends Object {
        CompareTo(value: Object): number
        CompareTo(value: number): number
        Equals(obj: Object): boolean
        Equals(obj: number): boolean
        GetHashCode(): number
        toString(format: string, provider: any): string
        toString(provider: any): string
        toString(format: string): string
        toString(): string
        GetTypeCode(): any
        static Parse(s: string, style: any, provider: any): number
        static Parse(s: string, style: any): number
        static Parse(s: string, provider: any): number
        static Parse(s: string): number
        static TryParse(s: string, style: any, provider: any, result: jsb.Out<number>): boolean
        static TryParse(s: string, result: jsb.Out<number>): boolean
        protected constructor()
        static readonly MaxValue: number
        static readonly MinValue: number
    }
}
declare module "System" {
    import * as jsb from "jsb";
    class UInt16 extends Object {
        CompareTo(value: Object): number
        CompareTo(value: number): number
        Equals(obj: Object): boolean
        Equals(obj: number): boolean
        GetHashCode(): number
        toString(format: string, provider: any): string
        toString(provider: any): string
        toString(format: string): string
        toString(): string
        GetTypeCode(): any
        static Parse(s: string, style: any, provider: any): number
        static Parse(s: string, style: any): number
        static Parse(s: string, provider: any): number
        static Parse(s: string): number
        static TryParse(s: string, style: any, provider: any, result: jsb.Out<number>): boolean
        static TryParse(s: string, result: jsb.Out<number>): boolean
        protected constructor()
        static readonly MaxValue: number
        static readonly MinValue: number
    }
}
declare module "System" {
    class Object {
        constructor()
        Equals(obj: Object): boolean
        GetHashCode(): number
        GetType(): any
        toString(): string
        static Equals(objA: Object, objB: Object): boolean
        static ReferenceEquals(objA: Object, objB: Object): boolean
    }
}
declare module "System" {
    import * as jsb from "jsb";
    abstract class Array<T, RANK = 1> extends Object {
        CopyTo(array: Array<any>, index: number): void
        Clone(): Object
        GetLongLength(dimension: number): number
        GetEnumerator(): any
        GetLength(dimension: number): number
        GetLowerBound(dimension: number): number
        GetValue(index1: number, index2: number, index3: number): T
        GetValue(index1: number, index2: number): T
        GetValue(index: number): T
        GetValue(...index: number[]): T
        SetValue(value: T, index1: number, index2: number, index3: number): T
        SetValue(value: T, index1: number, index2: number): T
        SetValue(value: T, index: number): T
        SetValue(value: T, ...index: number[]): T
        GetUpperBound(dimension: number): number
        Initialize(): void
        static BinarySearch<T>(array: Array<T>, index: number, length: number, value: Object, comparer: any): number
        static BinarySearch<T>(array: Array<T>, index: number, length: number, value: Object): number
        static BinarySearch<T>(array: Array<T>, value: Object, comparer: any): number
        static BinarySearch<T>(array: Array<T>, value: Object): number
        static IndexOf<T>(array: Array<T>, value: Object, startIndex: number, count: number): number
        static IndexOf<T>(array: Array<T>, value: Object, startIndex: number): number
        static IndexOf<T>(array: Array<T>, value: Object): number
        static LastIndexOf<T>(array: Array<T>, value: Object, startIndex: number, count: number): number
        static LastIndexOf<T>(array: Array<T>, value: Object, startIndex: number): number
        static LastIndexOf<T>(array: Array<T>, value: Object): number
        static Reverse<T>(array: Array<T>, index: number, length: number): void
        static Reverse<T>(array: Array<T>): void
        static Sort<T>(keys: Array<T>, items: Array<T>, index: number, length: number, comparer: any): void
        static Sort<T>(array: Array<T>, index: number, length: number, comparer: any): void
        static Sort<T>(keys: Array<T>, items: Array<T>, index: number, length: number): void
        static Sort<T>(array: Array<T>, index: number, length: number): void
        static Sort<T>(keys: Array<T>, items: Array<T>, comparer: any): void
        static Sort<T>(array: Array<T>, comparer: any): void
        static Sort<T>(keys: Array<T>, items: Array<T>): void
        static Sort<T>(array: Array<T>): void
        static CreateInstance<T>(elementType: any, length1: number, length2: number, length3: number): Array<T>
        static CreateInstance<T>(elementType: any, length1: number, length2: number): Array<T>
        static CreateInstance<T>(elementType: any, lengths: Array<number>, lowerBounds: Array<number>): Array<T>
        static CreateInstance<T>(elementType: any, length: number): Array<T>
        static CreateInstance<T>(elementType: any, ...lengths: number[]): Array<T>
        static Clear<T>(array: Array<T>, index: number, length: number): void
        static Copy<T>(sourceArray: Array<T>, sourceIndex: number, destinationArray: Array<T>, destinationIndex: number, length: number): void
        static Copy<T>(sourceArray: Array<T>, destinationArray: Array<T>, length: number): void
        static ConstrainedCopy<T>(sourceArray: Array<T>, sourceIndex: number, destinationArray: Array<T>, destinationIndex: number, length: number): void
        readonly LongLength: number
        readonly IsFixedSize: boolean
        readonly IsReadOnly: boolean
        readonly IsSynchronized: boolean
        readonly SyncRoot: Object
        readonly Length: number
        readonly Rank: number
    }
}
declare module "System" {
    import * as jsb from "jsb";
    abstract class Delegate extends Object {
        DynamicInvoke(...args: Object[]): Object
        Clone(): Object
        Equals(obj: Object): boolean
        GetHashCode(): number
        GetObjectData(info: any, context: any): void
        GetInvocationList(): Array<Delegate>
        static Combine(a: Delegate, b: Delegate): Delegate
        static Combine(...delegates: Delegate[]): Delegate
        static Remove(source: Delegate, value: Delegate): Delegate
        static RemoveAll(source: Delegate, value: Delegate): Delegate
        static op_Inequality(d1: Delegate, d2: Delegate): boolean
        // js_op_overloading: static ==(d1: Delegate, d2: Delegate): boolean
        readonly Method: any
        readonly Target: Object
    }
}
declare module "QuickJS.IO" {
    import * as jsb from "jsb";
    import { Object, Array } from "System";
    class ByteBuffer extends Object {
        constructor(initialCapacity: number, maxCapacity: number, allocator: any)
        constructor(data: Array<jsb.byte>, maxCapacity: number)
        constructor(data: Array<jsb.byte>)
        toString(): string
        Release(): void
        Retain(): ByteBuffer
        CheckReadalbe(size: number): void
        ReadBytes(dst: Array<jsb.byte>, dstOffset: number, size: number): number
        ReadBytes(pointer: any, size: number): number
        ReadBytes(count: number): void
        ReadUByte(): jsb.byte
        ReadSByte(): number
        ReadBoolean(): boolean
        ReadAllBytes(): Array<jsb.byte>
        ReadSingle(): number
        ReadDouble(): number
        ReadString(): string
        ReadInt16(): number
        ReadUInt16(): number
        ReadInt32(): number
        ReadUInt32(): number
        ReadInt64(): number
        ReadUInt64(): number
        EnsureCapacity(value: number): void
        WriteByte(data: jsb.byte): void
        WriteSByte(data: number): void
        WriteBytes(src: Array<jsb.byte>, srcOffset: number, count: number): void
        WriteBytes(memoryStream: any, size: number): void
        WriteBytes(other: ByteBuffer): void
        WriteBytes(byteCount: number): void
        WriteBytes(data: Array<jsb.byte>): void
        WriteBoolean(value: boolean): void
        WriteInt16(value: number): void
        WriteUInt16(value: number): void
        WriteInt32(value: number): void
        WriteUInt32(value: number): void
        WriteInt64(value: number): void
        WriteUInt64(value: number): void
        WriteSingle(value: number): void
        WriteDouble(value: number): void
        WriteString(value: string): void
        readonly data: Array<jsb.byte>
        readonly capacity: number
        writerIndex: number
        readonly readableBytes: number
        readerIndex: number
        readonly maxCapacity: number
        readonly isWritable: boolean
    }
}

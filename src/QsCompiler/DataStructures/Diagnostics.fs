﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Quantum.QsCompiler.Diagnostics

open System
open System.Collections.Generic

type ErrorCode =
    | ExcessBracketError = 1001
    | MissingBracketError = 1002
    | MissingStringDelimiterError = 1003
       
    | MisplacedOpeningBracket = 2001
    | ExpectingOpeningBracket = 2002
    | ExpectingSemicolon = 2003
    | UnexpectedFragmentDelimiter = 2004

    | UnknownCodeFragment = 3001
    | InvalidReturnStatement = 3002       
    | InvalidFailStatement = 3003       
    | InvalidImmutableBinding = 3004         
    | InvalidMutableBinding = 3005             
    | InvalidValueUpdate = 3006      
    | InvalidIfClause = 3007       
    | InvalidElifClause = 3008
    | InvalidElseClause = 3009            
    | InvalidForLoopIntro = 3010         
    | InvalidWhileLoopIntro = 3011
    | InvalidRepeatIntro = 3012       
    | InvalidUntilClause = 3013           
    | InvalidRUSfixup = 3014        
    | InvalidUsingBlockIntro = 3015              
    | InvalidBorrowingBlockIntro = 3016       
    | InvalidBodyDeclaration = 3017
    | InvalidAdjointDeclaration = 3018       
    | InvalidControlledDeclaration = 3019    
    | InvalidControlledAdjointDeclaration = 3020
    | InvalidOperationDeclaration = 3021
    | InvalidFunctionDeclaration = 3022 
    | InvalidTypeDefinition = 3023
    | InvalidNamespaceDeclaration = 3024        
    | InvalidOpenDirective = 3025
    | InvalidExpressionStatement = 3026 
    | InvalidConstructorExpression = 3027
    | MissingArgumentForFunctorGenerator = 3028
    | InvalidKeywordWithinExpression = 3029
    | InvalidUseOfReservedKeyword = 3030
    | ExcessContinuation = 3031
    | NonCallExprAsStatement = 3032

    | InvalidExpression = 3101
    | MissingExpression = 3102
    | InvalidIdentifierName = 3103
    | InvalidPathSegment = 3104
    | InvalidTypeName = 3105
    | InvalidTypeParameterName = 3106
    | InvalidTypeParameterList = 3107
    | MissingIdentifer = 3108
    | UnknownFunctorGenerator = 3109
    | InvalidAssignmentToExpression = 3110
    | ExpectingComma = 3111
    | ExpectingAssignment = 3112
    | ExpectingIteratorItemAssignment = 3113 // meaning expecting "in" keyword
    | UnknownSetName = 3114
    | InvalidOperationCharacteristics = 3115
    | MissingOperationCharacteristics = 3116
    | ExpectingUpdateExpression = 3117

    | InvalidIdentifierDeclaration = 3201
    | MissingIdentifierDeclaration = 3202
    | InvalidSymbolTupleDeclaration = 3203
    | MissingSymbolTupleDeclaration = 3204
    | InvalidQualifiedSymbol = 3205
    | MissingQualifiedSymbol = 3206
    | InvalidType = 3207
    | MissingType = 3208
    | InvalidTypeAnnotation = 3209
    | MissingTypeAnnotation = 3210
    | InvalidReturnTypeAnnotation = 3211
    | MissingReturnTypeAnnotation = 3212
    | InvalidInitializerExpression = 3213
    | MissingInitializerExpression = 3214
    | MissingLTupleBracket = 3215
    | MissingRTupleBracket = 3216
    | MissingLArrayBracket = 3217
    | MissingRArrayBracket = 3218
    | MissingLCurlyBracket = 3219
    | MissingRCurlyBracket = 3220
    | MissingLAngleBracket = 3221
    | MissingRAngleBracket = 3222
    | InvalidArgument = 3223
    | MissingArgument = 3224
    | InvalidArgumentDeclaration = 3225
    | MissingArgumentDeclaration = 3226
    | InvalidTypeParameterDeclaration = 3227
    | MissingTypeParameterDeclaration = 3228
    | InvalidTypeArgument = 3229
    | MissingTypeArgument = 3230
    | InvalidIdentifierExprInUpdate = 3231
    | MissingIdentifierExprInUpdate = 3232
    | InvalidUdtItemDeclaration = 3233
    | MissingUdtItemDeclaration = 3234
    | InvalidUdtItemNameDeclaration = 3235
    | MissingUdtItemNameDeclaration = 3236

    | EmptyValueArray = 3300 
    | InvalidValueArray = 3301
    | InvalidValueTuple = 3302
    | UpdateOfArrayItemExpr = 3303

    | NotWithinGlobalScope = 4001
    | NotWithinNamespace = 4002
    | NotWithinCallable = 4003
    | NotWithinSpecialization = 4004
    | MisplacedOpenDirective = 4005
    | RUSloopInFunction = 4006
    | UsingInFunction = 4007
    | BorrowingInFunction = 4008
    | AdjointDeclInFunction = 4009
    | ControlledDeclInFunction = 4010
    | ControlledAdjointDeclInFunction = 4011
    | InvalidReturnWithinAllocationScope = 4012
    | WhileLoopInOperation = 4013

    | MissingPreceedingIfOrElif = 4101
    | MissingContinuationUntil = 4102
    | MissingPreceedingRepeat = 4103
    | DistributedAdjointGenerator = 4105
    | InvalidBodyGenerator = 4106
    | BodyGenArgMismatch = 4107
    | AdjointGenArgMismatch = 4108
    | SelfControlledGenerator = 4109
    | InvertControlledGenerator = 4110
    | ControlledGenArgMismatch = 4111
    | ControlledAdjointGenArgMismatch = 4112

    | MissingExprInArray = 5001
    | MultipleTypesInArray = 5002
    | InvalidArrayItemIndex = 5003
    | ItemAccessForNonArray = 5004
    | InvalidTypeInArithmeticExpr = 5005
    | InvalidTypeForConcatenation = 5006
    | InvalidTypeInEqualityComparison = 5007
    | ArgumentMismatchInBinaryOp = 5008
    | TypeMismatchInConditional = 5009
    | ExpressionOfUnknownType = 5010
    | ExpectingUnitExpr = 5011
    | ExpectingIntExpr = 5012
    | ExpectingIntegralExpr = 5013
    | ExpectingBoolExpr = 5014
    | ExpectingStringExpr = 5015
    | ExpectingUserDefinedType = 5016
    | InvalidAdjointApplication = 5017
    | InvalidControlledApplication = 5018
    | ExpectingRangeOrInt = 5019
    | ExpectingIterableExpr = 5020
    | ExpectingCallableExpr = 5021
    | UnknownIdentifier = 5022

    | CallableRedefinition = 6001
    | CallableOverlapWithTypeConstructor = 6002
    | TypeRedefinition = 6003
    | TypeConstructorOverlapWithCallable = 6004
    | UnknownType = 6005
    | AmbiguousType = 6006 
    | UndefinedCallable = 6007
    | AmbiguousCallable = 6008
    | TypeSpecializationMismatch = 6009
    | SpecializationForUnknownCallable = 6010
    | RedefinitionOfBody = 6011
    | RedefinitionOfAdjoint = 6012
    | RedefinitionOfControlled = 6013
    | RedefinitionOfControlledAdjoint = 6014
    | RequiredUnitReturnForAdjoint = 6015
    | RequiredUnitReturnForControlled = 6016
    | RequiredUnitReturnForControlledAdjoint = 6017
    | AliasForNamespaceAlreadyExists = 6018
    | AliasForOpenedNamespace = 6019
    | InvalidNamespaceAliasName = 6020 // i.e. the chosen alias already exists

    | ExpectingUnqualifiedSymbol = 6101
    | ExpectingItemName = 6102
    | ExpectingIdentifier = 6103
    | UnknownNamespace = 6104
    | UnknownTypeInNamespace = 6105
    | TypeParameterRedeclaration = 6106
    | UnknownTypeParameterName = 6107
    | UnknownItemName = 6108

    | ArgumentTupleShapeMismatch = 6201
    | ArgumentTupleMismatch = 6202
    | ArrayBaseTypeMismatch = 6203
    | UserDefinedTypeMismatch = 6204
    | CallableTypeInputTypeMismatch = 6205
    | CallableTypeOutputTypeMismatch = 6206
    | MissingFunctorSupport = 6207
    | ExcessFunctorSupport = 6208
    | FunctorSupportMismatch = 6209
    | ArgumentTypeMismatch = 6210
    | UnexpectedTupleArgument = 6211
    | AmbiguousTypeParameterResolution = 6212
    | ConstrainsTypeParameter = 6213
    | DirectRecursionWithinTemplate = 6214
    | GlobalTypeAlreadyExists = 6215
    | GlobalCallableAlreadyExists = 6216
    | LocalVariableAlreadyExists = 6217
    | TypeParameterAlreadyExists = 6218
    | NamedItemAlreadyExists = 6219
    | IdentifierCannotHaveTypeArguments = 6220
    | WrongNumberOfTypeArguments = 6221
    | InvalidUseOfTypeParameterizedObject = 6222
    | PartialApplicationOfTypeParameter = 6223
    | IndirectlyReferencedExpressionType = 6224
    | TypeMismatchInCopyAndUpdateExpr = 6225

    | TypeMismatchInReturn = 6301
    | TypeMismatchInValueUpdate = 6302
    | UpdateOfImmutableIdentifier = 6303
    | SymbolTupleShapeMismatch = 6305
    | OperationCallOutsideOfOperation = 6306
    | MissingReturnOrFailStatement = 6307
    | TypeCannotContainItself = 6308
    | TypeIsPartOfCyclicDeclaration = 6309
    | UserDefinedImplementationForIntrinsic = 6310
    | NonSelfGeneratorForSelfadjoint = 6311
    | MissingFunctorForAutoGeneration = 6312
    | ReturnStatementWithinAutoInversion = 6313
    | ValueUpdateWithinAutoInversion = 6314
    | RUSloopWithinAutoInversion = 6315
    | QuantumDependencyOutsideExprStatement = 6316

    | UnexpectedCommandLineCompilerException = 7001
    | MissingInputFileOrSnippet = 7002
    | SnippetAndInputArguments = 7003
    | InvalidFilePath = 7004
    | UnknownSourceFile = 7005
    | UnknownProjectReference = 7007
    | CouldNotLoadSourceFile = 7008
    | FileIsNotAnAssembly = 7010
    | CouldNotExtractHeaders = 7011
    | MissingProjectReferenceDll = 7012
    | InvalidProjectOutputPath = 7013
    | SourceFilesMissing = 7014
    | UnexpectedCompilerException = 7015

    | FunctorGenerationFailed = 7101
    | CsGenerationFailed = 7102
    | QsGenerationFailed = 7103
    | DocGenerationFailed = 7104
    | GeneratingBinaryFailed = 7105
    | TargetExecutionFailed = 7106


type WarningCode = 
    | ExcessSemicolon = 2001
    | ExcessComma = 3001
    | DeprecatedUnitType = 3002
    | DeprecatedArgumentForFunctorGenerator = 3003
    | DeprecatedOpCharacteristics = 3101
    | DeprecatedOpCharacteristicsIntro = 3102
    | DeprecatedNOToperator = 3301
    | DeprecatedANDoperator = 3302
    | DeprecatedORoperator = 3303
    | DeprecatedRUSloopInFunction = 4001

    | DiscardingItemInAssignment = 5001 
    | ConditionalEvaluationOfOperationCall = 5002
    | TypeParameterNotResolvedByArgument = 6001
    | ReturnTypeNotResolvedByArgument = 6002
    | NamespaceAleadyOpen = 6003
    | NamespaceAliasIsAlreadyDefined = 6004 // same alias for the same namespace, hence (only) a warning
    | MissingBodyDeclaration = 6005
    | GeneratorDirectiveWillBeIgnored = 6301
    | UnreachableCode = 6302

    | DuplicateSourceFile = 7003
    | DuplicateProjectReference = 7004
    | DuplicateBinaryFile = 7005
    | ReferenceToUnknownProject = 7006
    | UnknownBinaryFile = 7007
    | CouldNotLoadBinaryFile = 7008
    | ReferencesSetToNull = 7009
    | UnresolvedItemsInGeneratedQs = 7101
    | TargetExitedAbnormally = 7102


type InformationCode = 
    | CommandLineArguments = 7001
    | CompilingWithSourceFiles = 7002
    | CompilingWithAssemblies = 7003

    | GeneratedCsCode = 7101
    | GeneratedQsCode = 7102
    | GeneratedCodeOutputFolder = 7103
    | BuildTargetOutput = 7104
    | BuildTargetError = 7105

    | FileContentInMemory = 7201
    | BuiltTokenization = 7202
    | BuiltSyntaxTree = 7203
    | FormattedQsCode = 7204


type DiagnosticItem = 
    | Error of ErrorCode
    | Warning of WarningCode
    | Information of InformationCode

    static member private ApplyArguments (args : IEnumerable<string>) str = 
        let args : obj[] = if args = null then [||] else [|for arg in args do yield arg|]
        try String.Format (str, args) 
        with | _ -> str // let's fail silently for now

    static member Message (code : ErrorCode, args : IEnumerable<string>) = 
        let ApplyArguments = DiagnosticItem.ApplyArguments args << function
            | ErrorCode.ExcessBracketError                      -> "No matching opening bracket for this closing bracket."
            | ErrorCode.MissingBracketError                     -> "An opening bracket has not been closed."
            | ErrorCode.MissingStringDelimiterError             -> "File ends with an unclosed string."
                                                            
            | ErrorCode.MisplacedOpeningBracket                 -> "Invalid placement of opening bracket."
            | ErrorCode.ExpectingOpeningBracket                 -> "Expecting opening bracket (\"{\")."
            | ErrorCode.ExpectingSemicolon                      -> "Expecting semicolon."
            | ErrorCode.UnexpectedFragmentDelimiter             -> "Unexpected statement delimiter."
                                                            
            | ErrorCode.UnknownCodeFragment                     -> "Syntax does not match any known patterns."
            | ErrorCode.InvalidReturnStatement                  -> "Syntax error in return-statement."    
            | ErrorCode.InvalidFailStatement                    -> "Syntax error in fail-statement."                
            | ErrorCode.InvalidImmutableBinding                 -> "Syntax error in immutable binding."                       
            | ErrorCode.InvalidMutableBinding                   -> "Syntax error in mutable binding."              
            | ErrorCode.InvalidValueUpdate                      -> "Syntax error in set-statement."              
            | ErrorCode.InvalidIfClause                         -> "Syntax error in if-clause."                      
            | ErrorCode.InvalidElifClause                       -> "Syntax error in elif-clause."                    
            | ErrorCode.InvalidElseClause                       -> "Syntax error in else-clause."                    
            | ErrorCode.InvalidForLoopIntro                     -> "Syntax error in for-statement." 
            | ErrorCode.InvalidWhileLoopIntro                   -> "Syntax error in while-statement."
            | ErrorCode.InvalidRepeatIntro                      -> "Syntax error in repeat header."                   
            | ErrorCode.InvalidUntilClause                      -> "Syntax error in until-clause."                     
            | ErrorCode.InvalidRUSfixup                         -> "Syntax error in fixup header."                     
            | ErrorCode.InvalidUsingBlockIntro                  -> "Syntax error in using-block header."               
            | ErrorCode.InvalidBorrowingBlockIntro              -> "Syntax error in borrowing-block header."          
            | ErrorCode.InvalidBodyDeclaration                  -> "Syntax error in body declaration."               
            | ErrorCode.InvalidAdjointDeclaration               -> "Syntax error in adjoint specialization declaration."            
            | ErrorCode.InvalidControlledDeclaration            -> "Syntax error in controlled specialization declaration."         
            | ErrorCode.InvalidControlledAdjointDeclaration     -> "Syntax error in controlled-adjoint specialization declaration."  
            | ErrorCode.InvalidOperationDeclaration             -> "Syntax error in operation declaration."          
            | ErrorCode.InvalidFunctionDeclaration              -> "Syntax error in function declaration."           
            | ErrorCode.InvalidTypeDefinition                   -> "Syntax error in type definition."                
            | ErrorCode.InvalidNamespaceDeclaration             -> "Syntax error in namespace declaration."           
            | ErrorCode.InvalidOpenDirective                    -> "Syntax error in open-directive."                                           
            | ErrorCode.InvalidExpressionStatement              -> "Syntax error in expression-statement." 
            | ErrorCode.InvalidConstructorExpression            -> "Syntax error in constructor expression."
            | ErrorCode.MissingArgumentForFunctorGenerator      -> "User-defined implementations of specializations require an argument."
            | ErrorCode.InvalidKeywordWithinExpression          -> "Invalid use of a reserved keyword within an expression."
            | ErrorCode.InvalidUseOfReservedKeyword             -> "The symbol is reserved for internal use only."
            | ErrorCode.ExcessContinuation                      -> "Unexpected code fragment."
            | ErrorCode.NonCallExprAsStatement                  -> "An expression used as a statement must be a call expression."
                                                            
            | ErrorCode.InvalidExpression                       -> "Syntax error in expression."
            | ErrorCode.MissingExpression                       -> "Expecting expression."
            | ErrorCode.InvalidIdentifierName                   -> "Identifiers need to start with an ASCII letter or an underscore, and need to contain at least one non-underscore character."
            | ErrorCode.InvalidPathSegment                      -> "All path segments need to start with an ASCII letter or an underscore, and need to contain at least one non-underscore character."
            | ErrorCode.InvalidTypeName                         -> "Type names need to start with an ASCII letter or an underscore, and need to contain at least one non-underscore character."
            | ErrorCode.InvalidTypeParameterName                -> "Type parameter names must be of the form \"'TName\"."
            | ErrorCode.InvalidTypeParameterList                -> "Type parameters must be separated by commas."
            | ErrorCode.MissingIdentifer                        -> "Incomplete path name."
            | ErrorCode.UnknownFunctorGenerator                 -> "Unknown functor generator. Possible generators are  \"auto\", \"distribute\", \"invert\", \"self\", or a user-defined implementation."
            | ErrorCode.InvalidAssignmentToExpression           -> "Cannot have an expression on the left hand side of the assignment."
            | ErrorCode.ExpectingComma                          -> "Expecting comma."
            | ErrorCode.ExpectingAssignment                     -> "Expecting assigment (\"=\")."
            | ErrorCode.ExpectingIteratorItemAssignment         -> "Expecting iteration keyword \"in\"."
            | ErrorCode.UnknownSetName                          -> "Invalid set name. Possible names are \"Ctl\", and \"Adj\"."
            | ErrorCode.InvalidOperationCharacteristics         -> "Syntax error in operation characteristics annotation."
            | ErrorCode.MissingOperationCharacteristics         -> "Expecting operation characteristics annotation."
            | ErrorCode.ExpectingUpdateExpression               -> "Expecting and expression of the form \"expr <- expr\"." 
                                                            
            | ErrorCode.InvalidIdentifierDeclaration            -> "Invalid identifier declaration. Expecting an unqualified symbol name."
            | ErrorCode.MissingIdentifierDeclaration            -> "Expecting an unqualified symbol name."
            | ErrorCode.InvalidSymbolTupleDeclaration           -> "Invalid symbol declaration. Expecting either a single symbol or a symbol tuple."
            | ErrorCode.MissingSymbolTupleDeclaration           -> "Expecting a single symbol or a symbol tuple."
            | ErrorCode.InvalidQualifiedSymbol                  -> "Invalid symbol name."
            | ErrorCode.MissingQualifiedSymbol                  -> "Expecting a qualified or unqualified symbol."
            | ErrorCode.InvalidType                             -> "Invalid type name."
            | ErrorCode.MissingType                             -> "Expecting a type name."
            | ErrorCode.InvalidTypeAnnotation                   -> "Invalid type annotation. Expecting a colon followed by a type."
            | ErrorCode.MissingTypeAnnotation                   -> "Expecting type annotation."
            | ErrorCode.InvalidReturnTypeAnnotation             -> "Invalid return type annotation. The argument tuple needs to be followed by a colon and the return type of the callable."
            | ErrorCode.MissingReturnTypeAnnotation             -> "Expecting return type annotation. The argument tuple needs to be followed by a colon and the return type of the callable."
            | ErrorCode.InvalidInitializerExpression            -> "Invalid initializer expression. Possible initializers are \"Qubit()\", \"Qubit[expr]\", or tuples thereof."
            | ErrorCode.MissingInitializerExpression            -> "Expecting initializer expression. Possible initializers are \"Qubit()\", \"Qubit[expr]\", or tuples thereof."
            | ErrorCode.MissingRTupleBracket                    -> "Expecting \")\"."
            | ErrorCode.MissingLTupleBracket                    -> "Expecting \"(\"."
            | ErrorCode.MissingRArrayBracket                    -> "Expecting \"]\"."
            | ErrorCode.MissingLArrayBracket                    -> "Expecting \"[\"."
            | ErrorCode.MissingRCurlyBracket                    -> "Expecting \"}\"."
            | ErrorCode.MissingLCurlyBracket                    -> "Expecting \"{\"."
            | ErrorCode.MissingRAngleBracket                    -> "Expecting \">\"."
            | ErrorCode.MissingLAngleBracket                    -> "Expecting \"<\"."
            | ErrorCode.InvalidArgument                         -> "Invalid argument. Expecting expression or missing argument indication (\"_\")."
            | ErrorCode.MissingArgument                         -> "Expecting expression or missing argument indication (\"_\")."
            | ErrorCode.InvalidArgumentDeclaration              -> "Invalid argument declaration. Expecting a symbol declaration followed by a type  (\"symbolName : SymbolType\")."
            | ErrorCode.MissingArgumentDeclaration              -> "Expecting a symbol declaration followed by a type (\"symbolName : SymbolType\")."
            | ErrorCode.InvalidTypeParameterDeclaration         -> "Invalid type parameter declaration. Expecting a type parameter name of the form \"'TName\"."
            | ErrorCode.MissingTypeParameterDeclaration         -> "Expecting a type parameter name of the form \"'TName\"."
            | ErrorCode.InvalidTypeArgument                     -> "Invalid type argument."
            | ErrorCode.MissingTypeArgument                     -> "Expecting a type argument."
            | ErrorCode.InvalidIdentifierExprInUpdate           -> "Invalid or immutable expression. Expecting a mutable identifier (i.e. an unqualified symbol) or a tuple thereof."
            | ErrorCode.MissingIdentifierExprInUpdate           -> "Missing identifier. Expecting a mutable identifier or a tuple thereof."
            | ErrorCode.InvalidUdtItemDeclaration               -> "Invalid item declaration. Expecting either a named item (\"itemName : ItemType\"), or an anonymous item as indicated by denoting the type only."
            | ErrorCode.MissingUdtItemDeclaration               -> "Missing item. Expecting either a named item (\"itemName : ItemType\"), or an anonymous item as indicated by denoting the type only." 
            | ErrorCode.InvalidUdtItemNameDeclaration           -> "Invalid item name. Expecting an unqualified symbol name."
            | ErrorCode.MissingUdtItemNameDeclaration           -> "Expecting an unqualified symbol name."
                                                            
            | ErrorCode.EmptyValueArray                         -> "Empty arrays of undefined type are not supported. Use \"new T[0]\" for a suitable type T instead."
            | ErrorCode.InvalidValueArray                       -> "Syntax error in value array. Expecting a comma separated list of expressions."
            | ErrorCode.InvalidValueTuple                       -> "Syntax error in value tuple. Expecting a comma separated list of tuple items."
            | ErrorCode.UpdateOfArrayItemExpr                   -> "Array items are immutable. To set an item \"idx\" of an array \"arr\" to a value \"expr\", use and reassign a copy-and-update expression instead: \"set arr w/= idx <- expr;\"."

            | ErrorCode.NotWithinGlobalScope                    -> "Namespace declarations can only occur on a global scope."
            | ErrorCode.NotWithinNamespace                      -> "Declarations and open-directives can only occur within a namespace."
            | ErrorCode.NotWithinCallable                       -> "Specialization declarations can only occur within an operation or function."
            | ErrorCode.NotWithinSpecialization                 -> "Statements can only occur within a callable or specialization declaration."
            | ErrorCode.MisplacedOpenDirective                  -> "Open directives can only occur at the beginning of a namespace."
            | ErrorCode.RUSloopInFunction                       -> "Repeat-until-success-loops cannot be used in functions. Please use a while-loop instead."
            | ErrorCode.UsingInFunction                         -> "Using-statements cannot be used in functions."
            | ErrorCode.BorrowingInFunction                     -> "Borrowing-statements cannot be used in functions."
            | ErrorCode.AdjointDeclInFunction                   -> "Adjoint specializations can only be defined for operations."
            | ErrorCode.ControlledDeclInFunction                -> "Controlled specializations can only be defined for operations."
            | ErrorCode.ControlledAdjointDeclInFunction         -> "Controlled-adjoint specializations can only be defined for operations."
            | ErrorCode.InvalidReturnWithinAllocationScope      -> "Return statements may only occur at the end of a using- or borrowing-block."
            | ErrorCode.WhileLoopInOperation                    -> "While-loops cannot be used in operations. Avoid conditional loops in operations if possible, and use a repeat-until-success pattern otherwise."
                                                            
            | ErrorCode.MissingPreceedingIfOrElif               -> "An elif- or else-block must be preceeded by an if- or elif-block."
            | ErrorCode.MissingContinuationUntil                -> "A repeat-block must be followed by an until-clause."
            | ErrorCode.MissingPreceedingRepeat                 -> "An until-clause must be preceeded by a repeat-block."
            | ErrorCode.DistributedAdjointGenerator             -> "Invalid generator for adjoint specialization. Valid generators are \"invert\", \"self\" and \"auto\"."
            | ErrorCode.InvalidBodyGenerator                    -> "Invalid generator for body specialization. A body specialization must be user defined (\"body (...)\"), or specified as intrinsic (\"body intrinsic\")."
            | ErrorCode.BodyGenArgMismatch                      -> "The argument to a user-defined body specialization must be of the form \"(...)\"."
            | ErrorCode.AdjointGenArgMismatch                   -> "The argument to a user-defined adjoint specialization must must be of the form \"(...)\"."
            | ErrorCode.SelfControlledGenerator                 -> "Invalid generator for controlled specialization. Valid generators are \"distributed\" and \"auto\"."
            | ErrorCode.InvertControlledGenerator               -> "Invalid generator for controlled specialization. Valid generators are \"distributed\" and \"auto\"."
            | ErrorCode.ControlledGenArgMismatch                -> "The argument to a user-defined controlled specialization must must be of the form \"(ctlQsName, ...)\"."
            | ErrorCode.ControlledAdjointGenArgMismatch         -> "The argument to a user-defined controlled-adjoint specialization must must be of the form \"(ctlQsName, ...)\"."
                                                            
            | ErrorCode.MissingExprInArray                      -> "Underscores cannot be used to denote missing array elements."
            | ErrorCode.MultipleTypesInArray                    -> "Array items must have a common base type."
            | ErrorCode.InvalidArrayItemIndex                   -> "Expecting an expression of type Int or Range. Got an expression of type {0}."
            | ErrorCode.ItemAccessForNonArray                   -> "The type {0} does not provide item access. Items can only be accessed for values of array type."
            | ErrorCode.InvalidTypeInArithmeticExpr             -> "The type {0} does not support arithmetic operators. Expecting an expression of type Int, BigInt or Double."
            | ErrorCode.InvalidTypeForConcatenation             -> "The type {0} does not support concatenation. Expecting an expression of array type."
            | ErrorCode.InvalidTypeInEqualityComparison         -> "The type {0} does not support equality comparison."
            | ErrorCode.ArgumentMismatchInBinaryOp              -> "The given arguments of type {0} and {1} do not have a common base type."
            | ErrorCode.TypeMismatchInConditional               -> "The returned values of type {0} and {1} in the conditional expression do not have a common base type."
            | ErrorCode.ExpressionOfUnknownType                 -> "Expression of unknown type."
            | ErrorCode.ExpectingUnitExpr                       -> "Expecting expression of type Unit. Only expressions of type Unit can be used as expression statements."
            | ErrorCode.ExpectingIntExpr                        -> "Expecting an expression of type Int. Got an expression of type {0} instead."
            | ErrorCode.ExpectingIntegralExpr                   -> "Expecting an expression of type Int or BigInt. Got an expression of type {0} instead."
            | ErrorCode.ExpectingBoolExpr                       -> "Expecting an expression of type Bool. Got an expression of type {0} instead."
            | ErrorCode.ExpectingStringExpr                     -> "Expecting an expression of type String. Got an expression of type {0} instead."
            | ErrorCode.ExpectingUserDefinedType                -> "The type of the expression needs to be a user defined type. The given expression is of type {0}."
            | ErrorCode.InvalidAdjointApplication               -> "No suitable adjoint specialization exists."
            | ErrorCode.InvalidControlledApplication            -> "No suitable controlled specialization exists."
            | ErrorCode.ExpectingRangeOrInt                     -> "Range expressions must be of the form \"start .. step .. end\" or \"start .. end\", where start, step and end have to be of type Int."
            | ErrorCode.ExpectingIterableExpr                   -> "The type {0} does not support iteration. Expecting an expression of array type or of type Range."
            | ErrorCode.ExpectingCallableExpr                   -> "The type of the expression must be a function or operation type. The given expression is of type {0}." 
            | ErrorCode.UnknownIdentifier                       -> "No identifier with that name exists."
                                                            
            | ErrorCode.CallableRedefinition                    -> "Invalid callable declaration. A function or operation with that name already exists."
            | ErrorCode.CallableOverlapWithTypeConstructor      -> "Invalid callable declaration. A type constructor with that name already exists."
            | ErrorCode.TypeRedefinition                        -> "Invalid type declaration. A type with that name already exists."
            | ErrorCode.TypeConstructorOverlapWithCallable      -> "Invalid type declaration. A function or operation that conflicts with the type constructor already exists."
            | ErrorCode.UnknownType                             -> "No type with that name exists in any of the open namespaces."
            | ErrorCode.AmbiguousType                           -> "Multiple open namespaces contain a type with that name. Use a fully qualified name instead. Open namespaces containing a type with that name are {0}."
            | ErrorCode.UndefinedCallable                       -> "No callable with that name exists in any of the open namespaces."
            | ErrorCode.AmbiguousCallable                       -> "Multiple open namespaces contain a callable with that name. Use a fully qualified name instead. Open namespaces containing a callable with that name are {0}." 
            | ErrorCode.TypeSpecializationMismatch              -> "Invalid specialization declaration. The type specializations do not match the expected number of type parameters. Expecting {0} type argument(s)."
            | ErrorCode.SpecializationForUnknownCallable        -> "No callable with that name exists in the current namespace. Specializations need to be delared in the same namespace as the callable they extend."
            | ErrorCode.RedefinitionOfBody                      -> "A body specialization for the given parameters already exists."
            | ErrorCode.RedefinitionOfAdjoint                   -> "An adjoint specialization for the given parameters already exists."
            | ErrorCode.RedefinitionOfControlled                -> "A controlled specialization for the given parameters already exists."
            | ErrorCode.RedefinitionOfControlledAdjoint         -> "A controlled-adjoint specialization for the given parameters already exists."
            | ErrorCode.RequiredUnitReturnForAdjoint            -> "Adjoint specializations can only be defined for operations returning Unit."
            | ErrorCode.RequiredUnitReturnForControlled         -> "Controlled specializations can only be defined for operations returning Unit."
            | ErrorCode.RequiredUnitReturnForControlledAdjoint  -> "Controlled-adjoint specializations can only be defined for operations returning Unit."
            | ErrorCode.AliasForNamespaceAlreadyExists          -> "The namespace had already been opened as \"{0}\"."
            | ErrorCode.AliasForOpenedNamespace                 -> "Namespace is already open. Cannot open namespace under a different name."
            | ErrorCode.InvalidNamespaceAliasName               -> "A namespace or a namespace short name \"{0}\" already exists."
                                                            
            | ErrorCode.ExpectingUnqualifiedSymbol              -> "Expecting an unqualified symbol name."
            | ErrorCode.ExpectingItemName                       -> "Expecting an item name, i.e. an unqualified symbol."
            | ErrorCode.ExpectingIdentifier                     -> "Expecting either a qualified or an unqualified symbol."
            | ErrorCode.UnknownNamespace                        -> "No namespace with that name exists."
            | ErrorCode.UnknownTypeInNamespace                  -> "No type with that name exists in that namespace."
            | ErrorCode.TypeParameterRedeclaration              -> "A type parameter with that name already exists."
            | ErrorCode.UnknownTypeParameterName                -> "No type parameter with that name exists."
            | ErrorCode.UnknownItemName                         -> "The type {0} does not define an item with name \"{1}\"."
                                                
            | ErrorCode.ArgumentTupleShapeMismatch              -> "The shape of the given tuple does not match the expected type. Got an argument of type {0}, expecting one of type {1} instead."
            | ErrorCode.ArgumentTupleMismatch                   -> "The type of the given tuple does not match the expected type. Got an argument of type {0}, expecting one of type {1} instead."
            | ErrorCode.ArrayBaseTypeMismatch                   -> "The array item type {0} does not match the expected type {1}."
            | ErrorCode.UserDefinedTypeMismatch                 -> "The type {0} does not match the expected user defined type {1}." 
            | ErrorCode.CallableTypeInputTypeMismatch           -> "The argument type {0} of the given callable does not match the expected type {1}."
            | ErrorCode.CallableTypeOutputTypeMismatch          -> "The return type {0} of the given callable does not match the expected type {1}."
            | ErrorCode.MissingFunctorSupport                   -> "The given argument does not support the required functor(s). Missing support for the functor(s) {0}." 
            | ErrorCode.ExcessFunctorSupport                    -> "The given argument is less general than the expected one due to requiring additional support for the functor(s) {0}."
            | ErrorCode.FunctorSupportMismatch                  -> "The set of supported functors does not match the expected type. Expecting support for the functor(s) {0}."
            | ErrorCode.ArgumentTypeMismatch                    -> "The type of the given argument does not match the expected type. Got an argument of type {0}, expecting one of type {1} instead."
            | ErrorCode.UnexpectedTupleArgument                 -> "Unexpected argument tuple. Expecting an argument of type {0}." 
            | ErrorCode.AmbiguousTypeParameterResolution        -> "The type parameter resolution for the call is ambiguous. Please provide explicit type arguments, e.g. Op<Int, Double>(arg)."
            | ErrorCode.ConstrainsTypeParameter                 -> "The given expression constrains the type parameter(s) {0}."
            | ErrorCode.DirectRecursionWithinTemplate           -> "Direct recursive calls within templates require explicit type arguments. Please provide type arguments, e.g. Op<Int, Double>(arg)."
            | ErrorCode.GlobalTypeAlreadyExists                 -> "A type with that name already exists."
            | ErrorCode.GlobalCallableAlreadyExists             -> "A callable with that name already exists."
            | ErrorCode.LocalVariableAlreadyExists              -> "A variable with that name already exists."
            | ErrorCode.TypeParameterAlreadyExists              -> "A type parameter with that name already exists."
            | ErrorCode.NamedItemAlreadyExists                  -> "An item with that name already exists."
            | ErrorCode.IdentifierCannotHaveTypeArguments       -> "The given identifier cannot have type arguments."
            | ErrorCode.WrongNumberOfTypeArguments              -> "The number of type arguments does not match the number of type parameters for this identifier. Expecting {0} type argument(s)."
            | ErrorCode.InvalidUseOfTypeParameterizedObject     -> "The type of the given expression cannot be determined. Provide explicit type arguments (\"identifier<commaSeparatedTypeArguments>\")."
            | ErrorCode.PartialApplicationOfTypeParameter       -> "Generic type parameters cannot be partially resolved."
            | ErrorCode.IndirectlyReferencedExpressionType      -> "The type {0} of the expression is defined in an assembly that is not referenced."
            | ErrorCode.TypeMismatchInCopyAndUpdateExpr         -> "The type {0} of the given expression is not compatible with the expected type {1}."

            | ErrorCode.TypeMismatchInReturn                    -> "The type {0} of the given expression is not compatible with the expected return type {1}."
            | ErrorCode.TypeMismatchInValueUpdate               -> "The type {0} of the given expression is not compatible with the type {1} of the identifier."
            | ErrorCode.UpdateOfImmutableIdentifier             -> "An immutable identifier cannot be modified."
            | ErrorCode.SymbolTupleShapeMismatch                -> "The shape of the symbol tuple is not compatible with the assigned expression of type {0}."
            | ErrorCode.OperationCallOutsideOfOperation         -> "Operations may only be called from within operations."
            | ErrorCode.MissingReturnOrFailStatement            -> "Not all code paths return a value."
            | ErrorCode.TypeCannotContainItself                 -> "A type declaration cannot reference itself."
            | ErrorCode.TypeIsPartOfCyclicDeclaration           -> "Cyclic type declaration. Types cannot mutually call each other." 
            | ErrorCode.UserDefinedImplementationForIntrinsic   -> "A specialization of this callable has been declared as intrinsic. User-defined specializations may only be given for non-intrinsic callables." 
            | ErrorCode.NonSelfGeneratorForSelfadjoint          -> "An adjoint or controlled adjoint specialization of this callable has been declared to be self-adjoint. This specialization needs to be self-adjoint as well." 
            | ErrorCode.MissingFunctorForAutoGeneration         -> "The called operation does not support the necessary functor(s) for the requested auto-generation of a specialization. Missing support for functor(s) {0}."
            | ErrorCode.ReturnStatementWithinAutoInversion      -> "Auto-generation of inversions is not supported for operations that contain explicit return-statements."
            | ErrorCode.ValueUpdateWithinAutoInversion          -> "Auto-generation of inversions is not supported for operations that contain set-statements."
            | ErrorCode.RUSloopWithinAutoInversion              -> "Auto-generation of inversions is not supported for operations that contain repeat-until-success-loops."
            | ErrorCode.QuantumDependencyOutsideExprStatement   -> "Auto-generation of inversions is not supported for operations that contain operation calls outside expression statements."
                               
            | ErrorCode.UnexpectedCommandLineCompilerException  -> "The command line compiler threw an exception."
            | ErrorCode.MissingInputFileOrSnippet               -> "The command line compiler needs a list of files or a code snippet to process."
            | ErrorCode.SnippetAndInputArguments                -> "The command line compiler can accept a list of files or a code snippet, but not both."
            | ErrorCode.InvalidFilePath                         -> "The full path for the file \"{0}\" could not be determined."
            | ErrorCode.UnknownSourceFile                       -> "Could not find the source file \"{0}\" to compile."
            | ErrorCode.UnknownProjectReference                 -> "Could not find the project file for the referenced project \"{0}\"."
            | ErrorCode.CouldNotLoadSourceFile                  -> "Unable to load source file \"{0}\"."
            | ErrorCode.FileIsNotAnAssembly                     -> "The given file \"{0}\" is not an valid assembly."
            | ErrorCode.CouldNotExtractHeaders                  -> "Unrecognized content in reference \"{0}\". The binary file may have been compiled with an incompatible compiler version."
            | ErrorCode.MissingProjectReferenceDll              -> "Missing binary file for project reference \"{0}\". Build the referenced project for its content to be detected correctly."
            | ErrorCode.InvalidProjectOutputPath                -> "Invalid project output path for project \"{0}\"."
            | ErrorCode.SourceFilesMissing                      -> "No source files have been specified."
            | ErrorCode.UnexpectedCompilerException             -> "The compiler threw an exception."

            | ErrorCode.FunctorGenerationFailed                 -> "Auto-generation of functor specialization(s) failed."
            | ErrorCode.CsGenerationFailed                      -> "Unable to generate C# code to run within the simulation framework."
            | ErrorCode.QsGenerationFailed                      -> "Unable to generate formatted Q# code based on the built syntax tree."
            | ErrorCode.DocGenerationFailed                     -> "Unable to generate documentation for the compiled code."
            | ErrorCode.GeneratingBinaryFailed                  -> "Unable to generate binary format for the compilation."
            | ErrorCode.TargetExecutionFailed                   -> "Processing of the compiled binary with the target {0} failed."
            | _                                                 -> "" 
        code |> ApplyArguments             
             
    static member Message (code : WarningCode, args : IEnumerable<string>) = 
        let ApplyArguments = DiagnosticItem.ApplyArguments args << function
            | WarningCode.ExcessSemicolon                       -> "Extra semicolon will be ignored."
            | WarningCode.ExcessComma                           -> "Extra comma will be ignored."
            | WarningCode.DeprecatedUnitType                    -> "Deprecated syntax. Use the type name \"Unit\" instead."
            | WarningCode.DeprecatedArgumentForFunctorGenerator -> "Deprecated syntax. An argument tuple is expected where \"...\" indicates the position of the declaration arguments, e.g. \"(...)\" for body and adjoint, \"(cs, ...)\" for controlled and controlled adjoint."
            | WarningCode.DeprecatedOpCharacteristics           -> "Deprecated syntax. Use \"{0}\" to denote the operation characteristics instead."
            | WarningCode.DeprecatedOpCharacteristicsIntro      -> "Deprecated syntax. Use \"is\" instead."
            | WarningCode.DeprecatedNOToperator                 -> "Deprecated syntax. Use \"not\" to denote the logical NOT operator."
            | WarningCode.DeprecatedANDoperator                 -> "Deprecated syntax. Use \"and\" to denote the logical AND operator."
            | WarningCode.DeprecatedORoperator                  -> "Deprecated syntax. Use \"or\" to denote the logical OR operator."
            | WarningCode.DeprecatedRUSloopInFunction           -> "The use of repeat-until-success-loops within functions may not be supported in the future. Please use a while-loop instead."

            | WarningCode.DiscardingItemInAssignment            -> "The expression on the right hand side is discarded on assignment and can be ommitted."
            | WarningCode.ConditionalEvaluationOfOperationCall  -> "This expression may be short-circuited, and operation calls may not be executed."
            | WarningCode.TypeParameterNotResolvedByArgument    -> "The value of the type parameter is not determined by the argument type. It will always have to be explicitly specified by passing type arguments." 
            | WarningCode.ReturnTypeNotResolvedByArgument       -> "The return type is not fully determined by the argument type. It will always have to be explicitly specified by passing type arguments."
            | WarningCode.NamespaceAleadyOpen                   -> "The namespace is already open."
            | WarningCode.NamespaceAliasIsAlreadyDefined        -> "A short name for this namespace is already defined."
            | WarningCode.MissingBodyDeclaration                -> "A body specification for this callable is missing. The callable is assumed to be intrinsic."
            | WarningCode.GeneratorDirectiveWillBeIgnored       -> "Generation directive ignored. A specialization of this callable has been declared as intrinsic."
            | WarningCode.UnreachableCode                       -> "This statement will never be executed."

            | WarningCode.DuplicateSourceFile                   -> "A source file with name \"{0}\" already exists in the compilation."
            | WarningCode.DuplicateProjectReference             -> "A project reference with name \"{0}\" already exists in the compilation."
            | WarningCode.DuplicateBinaryFile                   -> "A binary file with name \"{0}\" already exists in the compilation."
            | WarningCode.ReferenceToUnknownProject             -> "The referenced project \"{0}\" could not be found within the workspace folder."
            | WarningCode.UnknownBinaryFile                     -> "Could not find the binary file \"{0}\" to include as reference in the compilation."
            | WarningCode.CouldNotLoadBinaryFile                -> "Unable to load binary file \"{0}\"."
            | WarningCode.ReferencesSetToNull                   -> "No references given to include in the compilation."

            | WarningCode.UnresolvedItemsInGeneratedQs          -> "Some item(s) could not be resolved during compilation."
            | WarningCode.TargetExitedAbnormally                -> "Processing of the compiled binary with the target {0} exited with an abnormal exit code {1}."
            | _                                                 -> ""
        code |> ApplyArguments

    static member Message (code : InformationCode, args : IEnumerable<string>) = 
        let ApplyArguments = DiagnosticItem.ApplyArguments args << function
            | InformationCode.CommandLineArguments              -> "Compiling with command line arguments"
            | InformationCode.CompilingWithSourceFiles          -> "Compiling source files"
            | InformationCode.CompilingWithAssemblies           -> "Compiling with referenced assemblies"

            | InformationCode.GeneratedCsCode                   -> "C# code generated for simulation"
            | InformationCode.GeneratedQsCode                   -> "Formatted Q# code"
            | InformationCode.GeneratedCodeOutputFolder         -> "Code has been generated in output folder"
            | InformationCode.BuildTargetOutput                 -> "Build target output:"
            | InformationCode.BuildTargetError                  -> "Build target errors:"

            | InformationCode.FileContentInMemory               -> "Q# code to compile"
            | InformationCode.BuiltTokenization                 -> "Built tokenization"
            | InformationCode.BuiltSyntaxTree                   -> "Built syntax tree"
            | InformationCode.FormattedQsCode                   -> "Q# code generated based on the built syntax tree"

            | _                                                 -> ""
        code |> ApplyArguments
        

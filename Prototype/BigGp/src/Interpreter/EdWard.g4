grammar EdWard;

program: (line | COMMENT)* EOF;

line: statement | ifStatement | whileStatement | forStatement | scope | COMMENT;

statement:  (assignment | functionCall) ';';

ifStatement: 'if' '(' expression ')' block;

whileStatement: 'while' '(' expression ')' block;

forStatement: 'for' '(' assignment ',' expression ',' ('*' | '+' | '-') (IDENTIFIER | INTEGER) ')' block;

parameters: (expression (',' expression)*)?;

assignment: IDENTIFIER '=' expression;

functionCall: IDENTIFIER '(' parameters ')';

objectFunctionCall: IDENTIFIER '.'IDENTIFIER '(' parameters ')' objectFunctionCallFromFunction;

objectFunctionCallFromFunction: ('.'IDENTIFIER '(' parameters ')')*;

objectCreationCall: 'new' IDENTIFIER '(' parameters ')';

inplaceQuestion: '.'IDENTIFIER;


expression
    : constant                                   #constantExpression
    | IDENTIFIER                                 #identifierExpression
    | functionCall inplaceQuestion?              #functionExpression
    | '(' expression ')'                         #parenthesizedExpression
    | '!' expression                             #notExpression
    | objectFunctionCall inplaceQuestion?        #objectFunctionCallExpression
    | objectCreationCall                         #objectCreationCallExpression
    | expression multOp expression               #multiplicativeExpression
    | expression addOp expression                #additiveExpression
    | expression compareOp expression            #comparisonExpression
    | expression boolOp expression               #booleanExpression
    ;

multOp: '*' | '/';
addOp: '+' | '-';
compareOp: '==' | '!=' | '>' | '<' | '>=' | '<=';
boolOp: BOOL_OPERATOR;

BOOL_OPERATOR: 'and' | 'or';

constant: INTEGER | STRING | BOOL | NULL;

INTEGER: [0-9]+;
STRING: ('"' ~'"'* '"') | ('\'' ~'\''* '\'');
BOOL: 'true' | 'false';
NULL: 'null';


block: '{' line* '}';

scope: '[' line* ']';

COMMENT
    : '#' ~[+\-\r\n] ~[\r\n]* // a '*' must be followed by something other than '+', '-' or a line break
    | '#' ( [\r\n]+ | EOF );  // a '*' is a valid comment if directly followed by a line break, or the EOF ;

WS: [ \t\r\n]+ -> skip;
IDENTIFIER: '@'? [a-zA-Z_][a-zA-Z0-9_]*;

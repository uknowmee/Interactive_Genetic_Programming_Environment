# Interactive_Genetic_Programming_Environment

This is project I am currently working on. It is the focus of my engineering thesis and aims to
- <ins>investigate the impact of expert intervention on the effectiveness of genetic programming in code generation tasks.</ins>

The project is based on a previously implemented Java library that I created,
which uses genetic programming techniques to generate programs in a small,
custom interpretable programming language designed to solve simple mathematical and logical problems.
Programs are generated using known input and output data and evaluated using a user-defined fitness function.

---

# Future goals: 

- defining the test set - CSV + script, e.g. python (in the future "clickable").
- defining one or more loss functions - a script, e.g. python (in the future "clickable").
- the possibility of multi-stage evolution using previously generated populations <br/>
(different presentations of individuals, i.e. list of successive productions, AST, PT, .txt).

- expert intervention in the method of creating the initial population:
    - Min/max/avg length,
    - number of inputs and outputs,
    - Selection of programming structures and the number of their occurrence,
    - The number of nestings in the code,
    - program execution time,
    - Editing the chance of creating new variables and other programming constructs,
    - Injection of pre-existing individuals.
    
    
- user intervention in the way of performing evolutions:
    - View and edit size: population, tournament, dropout,
    - Dynamic change of the loss function (several prepared scripts, negative evaluation of programs with e.g. too many lines, certain structures, too many outputs),
    - Editing chance of mutation, crossing, transposition, reproduction and other genetic operations,
    - Refreshing the population,
    - Injecting pre-prepared individuals into the population.
    
Conducting research using the above-mentioned software and determining the translation of the human factor
for the time of learning. Defining the impact of expert intervention on the phenomenon of overfitting. Comparison
solutions of experiments with predetermined parameters and then conducting them with
human interference. Analysis of changes in the value of the loss function with the phenomenon of refreshing the population.

---


# Current results:
- The program should output a number (at any position in the output). 789. It can also return other numbers besides 789.
    ```
    x_0 = read();
    for (x_1 = 73, (36 < x_2), -x_1) {
      x_2 = 17;
    }
    x_1 = (61 / (71 * x_0));
    if ((x_0 < 95)) {
      if ((x_1 > x_1)) {
        x_2 = x_0;
      }
      write(x_1);
      write(x_1);
      x_0 = 54;
      x_0 = x_0;
    }
    for (x_0 = (88 * (25 * 60)), (x_0 >= 77), -x_1) {
      write(x_0);
      if ((89 < x_1)) {
        if ((x_0 != (47 - (14 * 60)))) {
          x_1 = ((x_1 / 72) - 90);
        }
        x_2 = x_1;
        for (x_1 = 44, (x_1 == (88 - 82)), +22) {
          x_3 = 87;
          x_3 = x_3;
        }
        for (x_2 = 42, (60 <= (93 * 11)), -8) {
          x_1 = 82;
        }
      }
      write(x_0);
    }
    ```
- The program should read the first two numbers from the input and return (only) their sum to the output. Only integers in the range [-9.9] can be input
    ```
    x_0 = read();
    x_1 = read();
    for (x_0 = (x_0 + x_1), (x_1 == (92 - x_1)), +x_1) {
      write(x_0);
      x_2 = (48 * 24);
    }
    if ((1 >= 19)) {
      x_1 = x_0;
    }
    write(x_0);
    ```
- As input, the program receives a vector of 3 integers in the range [-200, 200],
returns a vector the first two elements of the input vector
in which all negative numbers have been left converted to zeros.
    ```
    x_0 = read();
    x_1 = read();
    x_2 = read();
    if ((x_3 >= x_0)) {
      x_0 = x_3;
      x_3 = x_1;
    }
    if ((64 != (42 / (12 / 55)))) {
      if (((42 / (70 * 37)) != 0)) {
        write(x_0);
        if (((x_1 / 55) > x_1)) {
          for (x_1 = 0, (12 < x_1), +2) {
            for (x_1 = 0, (12 < 98), +2) {
              write(x_3);
            }
          }
          x_3 = (70 * 37);
        }
        x_2 = x_1;
        if ((55 > 55)) {
          for (x_1 = (42 / x_1), (77 < x_2), +88) {
          }
        }
        write(x_2);
      }
      x_2 = x_2;
      for (x_1 = 0, (12 < x_1), +88) {
        for (x_1 = 0, (12 < 98), +2) {
          write(x_3);
        }
      }
      x_3 = 42;
      x_3 = 42;
    }
    ```
    
---


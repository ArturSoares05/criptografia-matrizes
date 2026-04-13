# 🔐 Criptografia com Matrizes (ASP.NET Core MVC)

Aplicação web desenvolvida em ASP.NET Core MVC que implementa um algoritmo de criptografia baseado em multiplicação de matrizes 3x3, utilizando valores ASCII e aritmética modular (mod 256).

---

## 🚀 Funcionalidades

* Criptografia de textos
* Descriptografia utilizando matriz inversa
* Interface web simples e interativa
* Processamento em blocos de 9 caracteres

---

## 🧠 Como funciona

O processo de criptografia segue os seguintes passos:

1. O texto digitado é convertido em valores ASCII
2. Esses valores são organizados em matrizes 3x3 (blocos de 9 caracteres)
3. Cada matriz é multiplicada por uma matriz-chave
4. O resultado é convertido de volta para caracteres

Para descriptografar:

* Utiliza-se a **matriz inversa da chave**
* O processo é o mesmo, mas usando essa matriz inversa

---

## 🔢 Explicação simples da multiplicação de matrizes

A criptografia funciona aplicando matemática básica de álgebra linear.

Imagine duas matrizes:

Texto (bloco):

```
A B C
D E F
G H I
```

Chave:

```
a b c
d e f
g h i
```

Para calcular um valor da matriz resultante, fazemos:

```
resultado[linha, coluna] =
(A × a) + (B × d) + (C × g)
```

Ou seja:
👉 multiplicamos os valores da linha da matriz de texto
👉 pelos valores da coluna da matriz chave
👉 e somamos tudo

---

### 🔁 Exemplo prático

Se tivermos:

```
Texto:   [1 2 3]
Chave:   [2 0 1]
         [1 1 0]
         [0 2 1]
```

O primeiro valor do resultado será:

```
(1×2) + (2×1) + (3×0) = 2 + 2 + 0 = 4
```

---

## 🔄 Aritmética modular (mod 256)

Após a multiplicação, aplicamos:

```
valor % 256
```

Isso garante que o resultado sempre fique dentro do intervalo ASCII (0–255).

---

## 🔐 Sobre a matriz inversa

Para descriptografar corretamente, é necessário usar uma matriz inversa da chave.

Neste projeto:

* Foi utilizada uma matriz com inversa válida em mod 256
* A inversa foi previamente definida para garantir funcionamento correto

---

## 🛠️ Tecnologias utilizadas

* .NET 8
* ASP.NET Core MVC
* C#
* HTML / CSS

---

## 💻 Como executar o projeto

```bash
git clone https://github.com/seu-usuario/criptografia-matrizes.git
cd criptografia-matrizes
dotnet run
```

Depois, acesse no navegador:

```
https://localhost:xxxx
```

---

## 📸 Demonstração

*(adicione um print da aplicação aqui)*

```
![App funcionando](./screenshot.png)
```

---

## 🎯 Objetivo do projeto

Este projeto foi desenvolvido com o objetivo de:

* Aplicar conceitos de álgebra linear na prática
* Entender fundamentos de criptografia
* Desenvolver uma aplicação web com ASP.NET Core MVC

---

## 📌 Observações

* O projeto é educacional e não deve ser usado como método real de segurança
* A implementação é inspirada no Hill Cipher, adaptado para ASCII (mod 256)

---

## 👨‍💻 Autor

Artur Soares

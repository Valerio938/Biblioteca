# DB Biblioteca


CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY(1,1),
	codice_utente VARCHAR(250) DEFAULT NEWID(),

	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL UNIQUE
);

CREATE TABLE Libro(
	libroID INT PRIMARY KEY IDENTITY(1,1),
	codice_utente VARCHAR(250) DEFAULT NEWID(),

	titolo VARCHAR(250) NOT NULL,
	anno_pubblicazione DATE NOT NULL,
	disponibilita BIT NOT NULL
);



CREATE TABLE Prestito(
	prestitoID INT PRIMARY KEY IDENTITY(1,1),
	codice_utente VARCHAR(250) DEFAULT NEWID(),

	traccia_libro VARCHAR(250) NOT NULL,
	data_consegna DATE NOT NULL,
	data_ritiro DATE NOT NULL,

	utenteRIF INTEGER NOT NULL,
	libroRIF INTEGER NOT NULL,

	FOREIGN KEY(utenteRIF) REFERENCES Utente(utenteID) ON DELETE CASCADE,
	FOREIGN KEY(libroRIF) REFERENCES Libro(libroID) ON DELETE CASCADE,
	UNIQUE(utenteRIF,libroRIF)

);

INSERT INTO Utente (nome, cognome, email) VALUES
    ('John', 'Doe', 'johndoe@example.com'),
    ('Jane', 'Smith', 'janesmith@example.com'),
    ('Alice', 'Johnson', 'alicejohnson@example.com');


INSERT INTO Libro (titolo, anno_pubblicazione, email, disponibilita) VALUES
    ('The Great Gatsby', '1925-04-10', 'publisher@example.com', 1),
    ('To Kill a Mockingbird', '1960-07-11', 'publisher1@example.com', 0),
    ('Pride and Prejudice', '1813-01-28', 'publisher2@example.com', 1);


INSERT INTO Prestito (traccia_libro, data_consegna, data_ritiro, utenteRIF, libroRIF) VALUES
    ('12345', '2023-10-01', '2023-10-15', 1, 1),
    ('67890', '2023-11-05', '2023-11-20', 2, 2);



--SELECT * FROM Utente;
--SELECT * FROM Libro;
--SELECT * FROM Prestito;
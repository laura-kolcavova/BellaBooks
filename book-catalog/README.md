# BellaBooks Book Catalog

## About

BellaBooks Book Catalog is a service for managing books, book authors, book genres, book publishers, library branches and library prints.

## Use of BellaBooks Book Catalog

Ensure [Docker Desktop](https://www.docker.com/) is installed and open on your computer.

Run this command to create the image and tag it with the name book-catalog:

```Bash
docker build -t book-catalog .
```

To run the web API service, run the following command to start a new Docker container using the book-catalog image and expose the service on port 5000:

```Bash
docker run -it --rm -p 8000:80 --name book-catalog-container book-catalog
```

This service will be hosted on http://localhost:8000
import { EventEmitter, Injectable, Output } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Book } from '../book.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksService {



  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private booksUrl = "https://localhost:44375/api/book";

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    const url = `${this.booksUrl}/get`;
    return this.http.get<Book[]>(url);
  }

  getBook(id: number): Observable<Book> {
    const url = `${this.booksUrl}/getbyid/${id}`;
    return this.http.get<Book>(url);
  }

  addBook(book: Book): Observable<Book> {
    const url = `${this.booksUrl}/add`;
    return this.http.post<Book>(url, book, this.httpOptions);
  }

  searchByName(name: string): Observable<Book[]> {
    const url = `${this.booksUrl}/searchbyname/${name}`;
    return this.http.get<Book[]>(url);
  }

  updateBook(book: Book): Observable<Book> {
    const url = `${this.booksUrl}/update`;
    return this.http.put<Book>(url, book);
  }

  deleteBook(id: number): Observable<Book> {
    const url = `${this.booksUrl}/remove/${id}`;
    return this.http.delete<Book>(url);
  }



  uploadBookImage(files: any): Observable<any> {


    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    const url = `${this.booksUrl}/upload`;

    return this.http.post(url, formData, { reportProgress: true, observe: 'events' });
  }

}

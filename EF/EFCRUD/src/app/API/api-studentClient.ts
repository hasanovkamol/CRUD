import { HttpClient } from "@angular/common/http";
import { Inject, Injectable, InjectionToken, Optional } from "@angular/core";
import { Observable } from "rxjs";

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface IStudentClient {
  getAll(): Observable<void>;
  onSave(): Observable<void>;
  getStudentById(): Observable<void>;
  deleteStudent(): Observable<void>;
}

@Injectable({
  providedIn: 'root',
})
export class StudentClient implements IStudentClient{
  private http: HttpClient;
  private baseUrl: string;

  constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    this.http = http;
    this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
}

  getAll(): Observable<void> {
    throw new Error("Method not implemented.");
  }
  onSave(): Observable<void> {
    throw new Error("Method not implemented.");
  }
  getStudentById(): Observable<void> {
    throw new Error("Method not implemented.");
  }
  deleteStudent(): Observable<void> {
    throw new Error("Method not implemented.");
  }

}



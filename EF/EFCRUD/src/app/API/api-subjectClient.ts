import { HttpClient } from "@angular/common/http";
import { Inject, Injectable, InjectionToken, Optional } from "@angular/core";
import { Observable } from "rxjs";

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface ISubjectClient {
  getAll(): Observable<void>;
  onSave(): Observable<void>;
  getSubjectById(): Observable<void>;
  deleteSubject(): Observable<void>;
}

@Injectable({
  providedIn: 'root',
})
export class SubjectClient implements ISubjectClient{
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
  getSubjectById(): Observable<void> {
    throw new Error("Method not implemented.");
  }
  deleteSubject(): Observable<void> {
    throw new Error("Method not implemented.");
  }

}



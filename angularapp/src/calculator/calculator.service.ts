import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CalculatorService {
  private apiUrl = 'https://localhost:7205/api/calculator'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  performCalculation(calculation: CalculationVM): Observable<CalculationVM> {
    return this.http.post<CalculationVM>(this.apiUrl, calculation);
  }

  getCalculations(): Observable<any> {
    return this.http.get("https://localhost:7205/api/calculator");
  }
}
export interface CalculationVM {
  num1: number;
  num2: number;
  operation: string;
}

export interface CalculationsHistoryVM {
  id: number;
  num1: number;
  num2: number;
  operation: string;
  result: number;
}


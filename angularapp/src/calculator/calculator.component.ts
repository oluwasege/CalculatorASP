// calculator.component.ts
import { Component, OnInit } from '@angular/core';
import { CalculatorService } from './calculator.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {
  num1: number = 0;
  num2: number = 0;
  selectedOperation: string = 'add';
  result: number | null = null;
  calculations: CalculationsHistoryVM[] = [];

  constructor(private calculatorService: CalculatorService) { }

  ngOnInit(): void {
    this.getCalculationsResult();
  }

  performCalculation(): void {
    const calculation: CalculationVM = {
      num1: this.num1,
      num2: this.num2,
      operation: this.selectedOperation
    };

    this.calculatorService.performCalculation(calculation).subscribe(res => {
      this.getCalculationsResult();
    });
  }

  getCalculationsResult(): void {
    this.calculatorService.getCalculations().subscribe(res => {
      this.calculations = res.data;
      console.log(res);
    });
  }
}
export interface CalculationsHistoryVM {
  id: number;
  num1: number;
  num2: number;
  operation: string;
  result: number;
}

export interface CalculationVM {
  num1: number;
  num2: number;
  operation: string;
}

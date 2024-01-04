import { Component, OnInit } from '@angular/core';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-line',
  templateUrl: './line.component.html',
  styleUrls: ['./line.component.scss']
})
export class LineComponent implements OnInit {
  ngOnInit() {
    const salesChartCanvas = document.getElementById('salesChart') as HTMLCanvasElement;

    const salesChartData = {
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [
        {
          label: 'Digital Goods',
          backgroundColor: 'rgba(60,141,188,0.9',
          borderColor: 'rgba(60,141,188,0.8)',
          data: [28, 48, 40, 19, 86, 27, 90]
        },
        {
          label: 'Electronics',
          backgroundColor: 'rgba(210, 214, 222, 1)',
          borderColor: 'rgba(210, 214, 222, 1)',
          data: [65, 59, 80, 81, 56, 55, 40]
        }
      ]
    };

    const salesChartOptions = {
      maintainAspectRatio: false,
      responsive: true,
      legend: {
        display: false
      },
      scales: {
        x: {
          display: true,
          title: {
            display: true,
            text: 'Month'
          }
        },
        y: {
          display: true,
          title: {
            display: true,
            text: 'Value'
          }
        }
      }
    };

    new Chart(salesChartCanvas, {
      type: 'line',
      data: salesChartData,
      options: salesChartOptions
    });
  }
}

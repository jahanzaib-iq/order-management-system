import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Order } from '../../../core/models/order.model';
import { OrderService } from '../../../core/services/order.service';

@Component({
  selector: 'app-order-details',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './order-details.html',
  styleUrl: './order-details.scss'
})
export class OrderDetails implements OnInit {
  order?: Order;

  constructor(
    private route: ActivatedRoute,
    private orderService: OrderService
  ) {}

  ngOnInit(): void {
    const id = +this.route.snapshot.params['id'];
    this.loadOrder(id);
  }

  loadOrder(id: number): void {
    this.orderService.getOrder(id).subscribe(order => {
      this.order = order;
    });
  }

  getStatusClass(status: string): string {
    switch (status) {
      case 'pending': return 'bg-warning text-dark';
      case 'completed': return 'bg-success text-white';
      case 'cancelled': return 'bg-danger text-white';
      default: return 'bg-secondary text-white';
    }
  }
}
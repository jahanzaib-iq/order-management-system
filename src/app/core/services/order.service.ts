import { Injectable } from '@angular/core';
import { Order } from '../models/order.model';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private orders: Order[] = [
    {
      id: 1,
      customerName: 'John Doe',
      product: 'Laptop',
      quantity: 1,
      price: 999.99,
      status: 'pending',
      createdAt: new Date()
    }
  ];

  getOrders(): Observable<Order[]> {
    return of(this.orders);
  }

  getOrder(id: number): Observable<Order> {
    const order = this.orders.find(o => o.id === id);
    return of(order!);
  }

  createOrder(order: Omit<Order, 'id' | 'createdAt'>): Observable<Order> {
    const newOrder: Order = {
      ...order,
      id: Math.max(...this.orders.map(o => o.id)) + 1,
      createdAt: new Date()
    };
    this.orders.push(newOrder);
    return of(newOrder);
  }

  updateOrder(order: Order): Observable<Order> {
    const index = this.orders.findIndex(o => o.id === order.id);
    this.orders[index] = order;
    return of(order);
  }

  deleteOrder(id: number): Observable<void> {
    this.orders = this.orders.filter(o => o.id !== id);
    return of(void 0);
  }
}
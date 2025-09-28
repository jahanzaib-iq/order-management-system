import { Routes } from '@angular/router';
import { OrderList } from './features/orders/order-list/order-list';
import { OrderForm } from './features/orders/order-form/order-form';
import { OrderDetails } from './features/orders/order-details/order-details';

export const routes: Routes = [
  { path: '', redirectTo: '/orders', pathMatch: 'full' },
  { path: 'orders', component: OrderList },
  { path: 'orders/new', component: OrderForm },
  { path: 'orders/edit/:id', component: OrderForm },
  { path: 'orders/:id', component: OrderDetails }
];
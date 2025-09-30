import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { OrderService } from '../../../core/services/order.service';
import { Order } from '../../../core/models/order.model';

@Component({
  selector: 'app-order-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './order-form.html',
  styleUrl: './order-form.scss'
})
export class OrderForm implements OnInit {
  orderForm: FormGroup;
  isEdit = false; // This is used in the template
  orderId?: number;

  constructor(
    private fb: FormBuilder,
    private orderService: OrderService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.orderForm = this.createForm();
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.isEdit = true;
        this.orderId = +params['id'];
        this.loadOrder(this.orderId);
      }
    });
  }

  createForm(): FormGroup {
    return this.fb.group({
      customerName: ['', Validators.required],
      product: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]],
      price: [0, [Validators.required, Validators.min(0)]],
      status: ['pending', Validators.required]
    });
  }

  loadOrder(id: number): void {
    this.orderService.getOrder(id).subscribe(order => {
      this.orderForm.patchValue(order);
    });
  }

  onSubmit(): void {
    if (this.orderForm.valid) {
      if (this.isEdit && this.orderId) {
        const order: Order = {
          id: this.orderId,
          ...this.orderForm.value,
          createdAt: new Date()
        };
        this.orderService.updateOrder(order).subscribe(() => {
          this.router.navigate(['/orders']);
        });
      } else {
        this.orderService.createOrder(this.orderForm.value).subscribe(() => {
          this.router.navigate(['/orders']);
        });
      }
    }
  }
}
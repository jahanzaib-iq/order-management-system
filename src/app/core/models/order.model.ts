export interface Order {
  id: number;
  customerName: string;
  product: string;
  quantity: number;
  price: number;
  status: 'pending' | 'completed' | 'cancelled';
  createdAt: Date;
}
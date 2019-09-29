/* tslint:disable */
import { ProductView } from './product-view';
export interface MenuView  {
  id?: number;
  name?: null | string;
  products?: null | Array<ProductView>;
}

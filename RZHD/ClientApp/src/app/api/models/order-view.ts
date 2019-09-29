/* tslint:disable */
import { ProductView } from './product-view';
import { RestaurantView } from './restaurant-view';
import { StationView } from './station-view';
import { Status } from './status';
export interface OrderView  {
  id?: number;
  products?: null | Array<ProductView>;
  restaurants?: null | Array<RestaurantView>;
  stations?: null | Array<StationView>;
  status?: Status;
  totalPrice?: number;
}

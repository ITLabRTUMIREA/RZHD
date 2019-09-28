/* tslint:disable */
import { StationTimeView } from './station-time-view';
export interface RestaurantView  {
  id?: number;
  imageUrl?: null | string;
  name?: null | string;
  stationTime?: null | Array<StationTimeView>;
}

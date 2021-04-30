export interface IPropertyBase {
  Id: number;
  SellRent: number;
  Name: string;
  PType: string;
  FType: string;
  Price: number;
  BHK: number;
  BuiltArea: number;
  City: string;
  RTM: number; //properties ready to move or not
  Image?: string;
}
 
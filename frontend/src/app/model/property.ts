import { IPropertyBase } from './ipropertybase';

export class Property implements IPropertyBase {
  Id: number;
  SellRent: number;
  Name: string;
  PType: string;
  FType: string;
  Price: number;
  BHK: number;
  BuiltArea: number;
  CarpetArea?: number;
  Address: string;
  Address2: string;
  City: string;
  FloorNo?: string;
  TotalFloor?: string;
  RTM: number; //properties ready to move or not
  AOP?: string; //age of property
  MainEntrance?: string;
  Security?: number;
  Gated?: number;
  Maintenance?: number;
  Possession?: string;
  Image?: string;
  Description?: string;
  PostedOn: string;
  PostedBy: number;
}

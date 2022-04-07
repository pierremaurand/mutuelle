import { IPropertyBase } from "./ipropertybase";
import { Photo } from "./photo";

export class Property implements IPropertyBase {
  id?: number;
  sellRent?: number;
  name?: string;
  propertyType?: string;
  propertyTypeId?: number;
  furnishingType?: string;
  furnishingTypeId?: number;
  price?: number;
  bhk?: number;
  builtArea?: number;
  city?: string;
  cityId?: number;
  readyToMove?: boolean;
  image?: string;
  estPossessionOn?: string | null;
  possessionOn?: Date;
  carpetArea?: number;
  address?: string;
  address2?: string;
  floorNo?: number;
  totalFloors?: number;
  age?: string;
  mainEntrance?: string;
  security?: number;
  gated?: boolean;
  maintenance?: number;
  description?: string;
  photos?: Photo[];
}

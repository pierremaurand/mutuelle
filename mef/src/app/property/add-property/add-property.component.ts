import { DatePipe } from '@angular/common';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { City } from 'src/app/model/city';
import { IKeyValuePair } from 'src/app/model/ikeyvaluepair';
import { IPropertyBase } from 'src/app/model/ipropertybase';
import { Property } from 'src/app/model/property';
import { AlertifyService } from 'src/app/services/alertify.service';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})
export class AddPropertyComponent implements OnInit {
  @ViewChild('formTabs')
  formTabs!: TabsetComponent;
  @ViewChild("photos", { static: false })
  photoEl!: ElementRef;
  files: any[] = [];
  addPropertyForm!: FormGroup;
  nextClicked!: boolean;
  property = new Property();
  possessionOn!: Date;

  // Will come from masters
  propertyTypes!: IKeyValuePair[];
  furnishTypes!: IKeyValuePair[];
  cityList!: City[];

  propertyView: IPropertyBase = {

  };

  constructor(
    private datePipe: DatePipe,
    private fb: FormBuilder,
    private router: Router,
    private housingService: HousingService,
    private alertity: AlertifyService) { }

  ngOnInit(): void {
    if(!localStorage.getItem('userName')) {
      this.alertity.error("You must be loaged in to add a property");
      this.router.navigate(['/user/login']);
    }
    this.CreateAddPropertyForm();
    this.housingService.getAllCities().subscribe(data => {
      this.cityList = data;
      console.log(data);
    });

    this.housingService.getAllFurnishingTypes().subscribe(data => {
      this.furnishTypes = data;
      console.log(data);
    });

    this.housingService.getAllPropertyTypes().subscribe(data => {
      this.propertyTypes = data;
      console.log(data);
    });
  }

  CreateAddPropertyForm() {
    this.addPropertyForm = this.fb.group({
      BasicInfo: this.fb.group({
        SellRent: ['1', Validators.required],
        BHK: [null, Validators.required],
        PType: [null, Validators.required],
        FType: [null, Validators.required],
        Name: [null, Validators.required],
        City: [null, Validators.required]
      }),
      PriceInfo: this.fb.group({
        Price: [null, Validators.required],
        BuiltArea: [null, Validators.required],
        CarpetArea: [null],
        Security: [0],
        Maintenance: [null]
      }),
      AddressInfo: this.fb.group({
        FloorNo: [null],
        TotalFloor: [null],
        Address: [null, Validators.required],
        Address2: [""],
        LandMark: [null]
      }),
      OtherInfo: this.fb.group({
        RTM: ['true', Validators.required],
        PossessionOn: [null, Validators.required],
        Gated: [null],
        MainEntrance: [0],
        Description: [""]
      })
    });
  }

  onBack() {
    this.router.navigate(['/']);
  }

  estPossessionOn() {
    this.propertyView.estPossessionOn = this.PossessionOn.value;
  }

  onSubmit() {
    this.nextClicked = true;
    if(this.allTabsValid()) {
      this.mapProperty();
      console.log(this.property);
      this.housingService.addProperty(this.property).subscribe(
        (data: number) => {
          this.alertity.success("Congrats, your property listed successffully on our website");
          this.uploadFiles(data);
        }
      );
    } else {
      this.alertity.error('Please review the form and provide all valid entries');
    }
  }

  mapProperty(): void {
    this.property.sellRent = +this.SellRent.value;
    this.property.bhk = +this.BHK.value;
    this.property.propertyTypeId = this.PType.value;
    this.property.name = this.Name.value;
    this.property.cityId = this.City.value;
    this.property.furnishingTypeId = this.FType.value;
    this.property.price = +this.Price.value;
    this.property.security = +this.Security.value;
    this.property.maintenance = +this.Maintenance.value;
    this.property.builtArea = +this.BuiltArea.value;
    this.property.carpetArea = +this.CarpetArea.value;
    this.property.floorNo = +this.FloorNo.value;
    this.property.totalFloors = +this.TotalFloor.value;
    this.property.address = this.Address.value;
    this.property.address2 = this.Address2.value;
    this.property.readyToMove = this.RTM.value;
    this.property.gated = this.Gated.value;
    this.property.mainEntrance = this.MainEntrance.value;
    this.property.estPossessionOn = this.datePipe.transform(this.PossessionOn.value,'MM/dd/yyyy');
    this.property.description = this.Description.value;
  }

  allTabsValid(): boolean {
    if(this.BasicInfo.invalid) {
      this.formTabs.tabs[0].active = true;
      return false;
    }

    if(this.PriceInfo.invalid) {
      this.formTabs.tabs[1].active = true;
      return false;
    }

    if(this.AddressInfo.invalid) {
      this.formTabs.tabs[2].active = true;
      return false;
    }

    if(this.OtherInfo.invalid) {
      this.formTabs.tabs[3].active = true;
      return false;
    }
    return true;
  }

  selectTab(tabId: number, isCurrentTabValid: boolean) {
    this.nextClicked = true;
    if(isCurrentTabValid) {
      this.formTabs.tabs[tabId].active = true;
    }
  }

  //------------------------------------------
  // Getter Methods
  //------------------------------------------
  //

  //#region <Getter Methods>
    //#region <FormGroups>
      get BasicInfo() {
        return this.addPropertyForm.controls['BasicInfo'] as FormGroup;
      }

      get PriceInfo() {
        return this.addPropertyForm.controls['PriceInfo'] as FormGroup;
      }

      get AddressInfo() {
        return this.addPropertyForm.controls['AddressInfo'] as FormGroup;
      }

      get OtherInfo() {
        return this.addPropertyForm.controls['OtherInfo'] as FormGroup;
      }
    //#endregion
    //#region <FormControls>
    get SellRent() {
      return this.BasicInfo.controls['SellRent'] as FormControl;
    }

    get BHK() {
      return this.BasicInfo.controls['BHK'] as FormControl;
    }

    get PType() {
      return this.BasicInfo.controls['PType'] as FormControl;
    }

    get FType() {
      return this.BasicInfo.controls['FType'] as FormControl;
    }

    get Name() {
      return this.BasicInfo.controls['Name'] as FormControl;
    }

    get City() {
      return this.BasicInfo.controls['City'] as FormControl;
    }

    get Price() {
      return this.PriceInfo.controls['Price'] as FormControl;
    }

    get BuiltArea() {
      return this.PriceInfo.controls['BuiltArea'] as FormControl;
    }

    get CarpetArea() {
      return this.PriceInfo.controls['CarpetArea'] as FormControl;
    }

    get Security() {
      return this.PriceInfo.controls['Security'] as FormControl;
    }

    get Maintenance() {
      return this.PriceInfo.controls['Maintenance'] as FormControl;
    }

    get FloorNo() {
      return this.AddressInfo.controls['FloorNo'] as FormControl;
    }

    get TotalFloor() {
      return this.AddressInfo.controls['TotalFloor'] as FormControl;
    }

    get Address() {
      return this.AddressInfo.controls['Address'] as FormControl;
    }

    get Address2() {
      return this.AddressInfo.controls['Address2'] as FormControl;
    }

    get LandMark() {
      return this.AddressInfo.controls['LandMark'] as FormControl;
    }

    get RTM() {
      return this.OtherInfo.controls['RTM'] as FormControl;
    }

    get PossessionOn() {
      return this.OtherInfo.controls['PossessionOn'] as FormControl;
    }

    get AOP() {
      return this.OtherInfo.controls['AOP'] as FormControl;
    }

    get Gated() {
      return this.OtherInfo.controls['Gated'] as FormControl;
    }

    get MainEntrance() {
      return this.OtherInfo.controls['MainEntrance'] as FormControl;
    }

    get Description() {
      return this.OtherInfo.controls['Description'] as FormControl;
    }
    //#endregion
  //#endregion

  /**
   * on file drop handler
   */
  onFileDropped($event: any) {
    this.prepareFilesList($event);
  }

  /**
   * handle file from browsing
   */
  fileBrowseHandler(event: Event) {
    const element = event.currentTarget as HTMLInputElement;
    let fileList = element.files;
    const files = Array.prototype.slice.call(fileList);
    this.prepareFilesList(files);
  }

  /**
   * Convert Files list to normal array list
   * @param files (Files List)
   */
  prepareFilesList(files: Array<any>) {
    for (const item of files) {
      var reader = new FileReader();
      reader.onload = () => {
        item.imageUrl = reader.result as string;
      }
      reader.readAsDataURL(item);
      item.isPrimary = false;
      item.onUpload = false;
      item.progress = 0;
      this.files.push(item);
    }
    this.photoEl.nativeElement.value = "";
  }

  /**
   * format bytes
   * @param bytes (File size in bytes)
   * @param decimals (Decimals point)
   */
  formatBytes(bytes: number, decimals = 2) {
    if(bytes === 0) {
      return "0 Bytes";
    }
    const k = 1024;
    const dm = decimals <= 0 ? 0 : decimals;
    const sizes = ["Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + " " + sizes[i];
  }

  isPrimary(idx: number):void {
    for(let i = 0; i < this.files.length; i++ ) {
      this.files[i].isPrimary = false;
    }
    this.files[idx].isPrimary = true;
    this.propertyView.photo = this.files[idx].imageUrl;
  }

  deleteFile(idx: number): void {
    if(this.files[idx].isPrimary) {
      this.propertyView.photo = undefined;
    }
    this.files.splice(idx, 1);
  }

  upload(propId: number, file: File, idx: number): void {
    if(file) {
      this.files[idx].onUpload = true;
      this.housingService.uploadPhoto(file, propId).subscribe(
        event => {
          if(event.type === HttpEventType.UploadProgress) {
            this.files[idx].progress = Math.round(100 * event.loaded / event.total);
          } else if (event.type === HttpEventType.Response) {
            this.alertity.success("Upladed the file successfully: " + file.name);
          }
        });
    }
  }

  uploadFiles(propId: number): void {
    if(this.files) {
      for (let i = 0; i < this.files.length; i++) {
        this.upload(propId, this.files[i], i);
      }
    }

    if(this.SellRent.value === '2') {
      this.router.navigate(['/rent-property']);
    } else {
      this.router.navigate(['/']);
    }
  }

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
  NgxGalleryAnimation,
  NgxGalleryImage,
  NgxGalleryOptions,
} from '@kolkov/ngx-gallery';
import { Property } from 'src/app/model/property';
import { HousingService } from 'src/app/services/housing.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.scss'],
})
export class PropertyDetailComponent implements OnInit {
  public propertyId!: number;
  mainPhotoUrl!: string;
  property = new Property();
  galleryOptions!: NgxGalleryOptions[];
  galleryImages!: NgxGalleryImage[];
  imagesUrl = environment.imagesUrl;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private housingService: HousingService
  ) {}

  ngOnInit(): void {
    this.propertyId = this.route.snapshot.params['id'];
    this.route.data.subscribe((data: any) => {
      this.property = data['prp'];
      if (this.property.estPossessionOn) {
        this.property.age = this.housingService.getPropertyAge(
          this.property.estPossessionOn
        );
      }
    });

    this.galleryOptions = [
      {
        width: '100%',
        height: '465px',
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: true,
      },
    ];

    this.galleryImages = this.getPropertyPhotos();
  }

  getPropertyPhotos(): NgxGalleryImage[] {
    const photosUrls: NgxGalleryImage[] = [];
    if (this.property.photos) {
      for (const photo of this.property.photos) {
        if (photo.isPrimary) {
          this.mainPhotoUrl = photo.imageUrl;
        } else {
          photosUrls.push({
            small: photo.imageUrl,
            medium: photo.imageUrl,
            big: photo.imageUrl,
          });
        }
      }
    }
    return photosUrls;
  }
}

import { Component, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/Membre';
import { Search } from 'src/app/model/search';
import { LoaderService } from 'src/app/services/loader.service';
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-membre-list',
  templateUrl: './membre-list.component.html',
  styleUrls: ['./membre-list.component.scss'],
})
export class MembreListComponent implements OnInit {
  imagesUrl = environment.imagesUrl;
  membres: Membre[] = [];
  listeMembres: Membre[] = [];
  name: string = '';
  searchName: string = '';
  membre: Membre = new Membre();
  count: number = 0;
  searchCount: number = 0;
  search: string = '';
  singular: string = 'Membre';

  constructor(
    private membreService: MembreService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    this.membre.photoUrl = this.membreService.getPhotoUrl(this.membre);
    this.loaderService.show();
    this.membreService.getAll().subscribe({
      next: (data) => {
        this.loaderService.hide();
        (this.membres = data),
          this.membres.map((m, i) => {
            this.membres[i].photoUrl = this.membreService.getPhotoUrl(m);
          }),
          (this.count = this.membres.length),
          (this.searchCount = this.membres.length),
          this.onSearchChange('');
      },
    });
  }

  showProfile(membre: Membre): void {
    this.membre = membre;
  }

  onSearchChange(search: string): void {
    this.search = search;
    this.listeMembres = this.membres.filter((m) =>
      m.nom.toLowerCase().includes(this.search.toLowerCase())
    );
    this.searchCount = this.listeMembres.length;
  }
}

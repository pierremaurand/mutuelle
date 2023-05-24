import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-liste-choix-membre',
  templateUrl: './liste-choix-membre.component.html',
  styleUrls: ['./liste-choix-membre.component.scss'],
})
export class ListeChoixMembreComponent implements OnInit {
  membres: MembreList[] = [];
  search: string = '';
  @Output()
  membreChoisie = new EventEmitter<MembreList>();

  constructor(private membreService: MembreService) {}

  ngOnInit(): void {
    this.membreService.getAll().subscribe((membres: MembreList[]) => {
      this.membres = membres;
    });
  }

  sendMembre(membre: MembreList): void {
    this.membreChoisie.emit(membre);
    this.closeModal();
  }

  closeModal(): void {
    this.search = '';
  }
}

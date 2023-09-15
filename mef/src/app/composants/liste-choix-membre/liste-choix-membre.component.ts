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
  membres: Membre[] = [];
  search: string = '';
  width: number = 32;
  @Output()
  membreChoisie = new EventEmitter<number>();

  constructor(private membreService: MembreService) {}

  ngOnInit(): void {
    this.membreService.getAll().subscribe((membres: Membre[]) => {
      this.membres = membres;
    });
  }

  sendMembre(id: number): void {
    this.membreChoisie.emit(id);
    this.closeModal();
  }

  closeModal(): void {
    this.search = '';
  }
}

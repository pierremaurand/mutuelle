import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Membre } from 'src/app/model/Membre';
import { MembreService } from 'src/app/services/membre.service';
import Swal from 'sweetalert2';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-import-membre',
  templateUrl: './import-membre.component.html',
  styleUrls: ['./import-membre.component.scss'],
})
export class ImportMembreComponent implements OnInit {
  membres: Membre[] = [];
  data: [][] = [];

  constructor(private router: Router, private membreService: MembreService) {}

  ngOnInit(): void {}

  onImport(): void {
    if (this.checkInfosMembres()) {
      this.membreService.import(this.membres).subscribe(() => {
        Swal.fire({
          icon: 'success',
          title: 'Membres ajoutés avec succès !',
          showConfirmButton: false,
          timer: 1500,
        });
        this.onCancel();
      });
    } else {
      Swal.fire({
        icon: 'error',
        title: "Vous n'avez selectionné aucun fichier",
        showConfirmButton: false,
        timer: 1500,
      });
    }
  }

  checkInfosMembres(): boolean {
    if (this.membres.length !== 0) {
      return true;
    }
    return false;
  }

  onCancel(): void {
    this.router.navigate(['home/membres']);
  }

  onFileChange(event: any): void {
    const target: DataTransfer = <DataTransfer>event.target;

    if (target.files.length !== 1) {
      throw new Error('Vous devez choisir un seul fichier');
    }

    const reader: FileReader = new FileReader();

    reader.onload = (e: any) => {
      const bstr: string = e.target.result;

      const wb: XLSX.WorkBook = XLSX.read(bstr, { type: 'binary' });

      const wsname: string = wb.SheetNames[0];

      const ws: XLSX.WorkSheet = wb.Sheets[wsname];

      (this.data = XLSX.utils.sheet_to_json(ws, { header: 2 })),
        this.chargementListe();
    };

    reader.readAsBinaryString(target.files[0]);
  }

  chargementListe(): void {
    this.membres.length = 0;
    this.data.forEach((row) => {
      let membre: Membre = JSON.parse(JSON.stringify(row));
      this.membres.push(membre);
    });
  }
}

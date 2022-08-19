import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { PassengerRoutingModule } from './passenger-routing.module';
import { IndexComponent } from './index/index.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { DetailsComponent } from './details/details.component';
import { BookComponent } from './book/book.component';


@NgModule({
  declarations: [
    IndexComponent,
    CreateComponent,
    EditComponent,
    DetailsComponent,
    BookComponent
  ],
  imports: [
    CommonModule,
    PassengerRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    PassengerRoutingModule
  ]
})
export class PassengerModule { }

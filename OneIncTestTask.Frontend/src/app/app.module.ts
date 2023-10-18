import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { StringEncodingService } from './_services/string-encoding.service';

import { AppComponent } from './app.component';
import { EncoderComponent } from './encoder/encoder.component';

@NgModule({
  declarations: [
    AppComponent,
    EncoderComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [StringEncodingService],
  bootstrap: [AppComponent]
})
export class AppModule { }

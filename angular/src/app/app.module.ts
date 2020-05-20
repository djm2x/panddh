import { LoaderModule } from './loader/loader.module';
import { MatModule } from './mat.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injector } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InjectService } from './inject.service';
import { AppRoutingModule } from './app-routing.module';
import { MessageComponent } from './shared/snakebar.service';
import { LoaderInterceptor } from './loader/loader-interceptor';
import { DeleteComponent } from './admin/components/delete/delete.component';
import { SheetbottomComponent } from './admin/components/sheetbottom/sheetbottom.component';
import { MAT_DIALOG_DEFAULT_OPTIONS, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';



@NgModule({
  declarations: [
    AppComponent,
    MessageComponent,
    DeleteComponent,
    SheetbottomComponent,
  ],
  entryComponents: [
    DeleteComponent,
    SheetbottomComponent,
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    BrowserAnimationsModule,
    LoaderModule,

    // MatSnackBarModule,
    // MatProgressSpinnerModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptor,
      multi: true
    },
    // { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { direction: 'rtl' } },
    // { provide: MatDialogRef, useValue: {} },
    // { provide: MAT_DIALOG_DATA, useValue: {} }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private injector: Injector) {    // Create global Service Injector.
    InjectService.injector = this.injector;
  }
}

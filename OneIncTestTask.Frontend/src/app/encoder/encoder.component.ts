import { Component } from '@angular/core';
import { StringEncodingService } from '../_services/string-encoding.service';
import { HttpDownloadProgressEvent, HttpEventType } from '@angular/common/http';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-encoder',
  templateUrl: './encoder.component.html',
  styleUrls: ['./encoder.component.css']
})
export class EncoderComponent {
  constructor(private encodingService: StringEncodingService) {}

  private m_unsubscribe: Subject<void> = new Subject();
  public encodingResult: string = "";
  public operationInProgress: boolean = false;

  public fetchData(string: string) {
    const response = this.encodingService.encode(string);

    this.operationInProgress = true;
    this.encodingResult = "";

    response.pipe(takeUntil(this.m_unsubscribe)).subscribe(
      {
        next: (event) => {
          if (event.type === HttpEventType.Sent) {
            console.log('Request sent!');
          } else if (event.type === HttpEventType.DownloadProgress) {
            const text = (<HttpDownloadProgressEvent>event).partialText;
            this.encodingResult  = text ?? "";
            console.log('Received chunk:', event);
          }
        },
        error: (error) =>{
          console.log('Error returned: ', error);
          this.operationInProgress=false;
        },
        complete: () => {
          console.log('Request completed!');
          this.operationInProgress=false;
        }
      }
    )
  }

  public cancelOperation(){
    console.log('Request canceled!');
    this.m_unsubscribe.next();
    this.operationInProgress=false;
    this.encodingResult = "";
  }
}

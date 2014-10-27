//
//  BIDViewController.m
//  FateApp
//
//  Created by fengxi on 14-10-27.
//  Copyright (c) 2014年 fengxi. All rights reserved.
//

#import "BIDViewController.h"
#import "ASIHTTPRequest.h"
@interface BIDViewController ()

@end

@implementation BIDViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}
- (IBAction)testASIhttp:(id)sender {
    NSURL *url = [NSURL URLWithString:@"http://192.168.211.1/ServiceForIOS.svc/json/100"];
    ASIHTTPRequest *request = [ASIHTTPRequest requestWithURL:url];
    // ASIHTTPRequest *request2=[ASIHTTPRequest requ`];
    [request startSynchronous];
    NSError *error = [request error];
    if (!error) {
        NSData *response = [request responseData];
        NSDictionary *data=[NSJSONSerialization JSONObjectWithData:response options:0 error:&error];
        /*  UIAlertView *alertView = [[UIAlertView alloc] initWithTitle:@"JSON格式"
         message:response
         delegate:nil
         cancelButtonTitle:@"OK"
         otherButtonTitles:nil];
         [alertView show];
         */
        // [alertView release];
        
        self.lable.text=[data objectForKey:@"JSONDataResult"];
    }

}

@end

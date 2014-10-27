//
//  BIDViewController.m
//  FateApp
//
//  Created by fengxi on 14-10-27.
//  Copyright (c) 2014年 fengxi. All rights reserved.
//

#import "BIDViewController.h"
#import "ASIHTTPRequest.h"
#define  ServerUrl "http://192.168.211.1/ServiceForIOS.svc/"
@interface BIDViewController ()
//-(void)CreateUser;
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
    [request startSynchronous];
    NSError *error = [request error];
    if (!error) {
        NSData *response = [request responseData];
        NSDictionary *data=[NSJSONSerialization JSONObjectWithData:response options:0 error:&error];
        self.lable.text=[data objectForKey:@"JSONDataResult"];
    }

}

- (IBAction)TestforWcf:(id)sender {
    NSMutableDictionary *registerInfo=[[NSMutableDictionary alloc]init];
    [registerInfo setValue:@"Keith" forKey:@"name"];
    [registerInfo setValue:@"1" forKey:@"sex"];
    [registerInfo setValue:@"111966" forKey:@"Md5_password"];
    [registerInfo setValue:@"1" forKey:@"role"];
    [registerInfo setValue:@"xiooix@126.com" forKey:@"email"];
    [registerInfo setValue:@"15501025919" forKey:@"phoneNum"];
    NSError *error=nil;
    NSData *Jsondata=[NSJSONSerialization dataWithJSONObject:registerInfo options:NSJSONWritingPrettyPrinted error:&error];
    NSMutableData *multablejsondata=[NSMutableData dataWithData:Jsondata];
    NSMutableString *Str_serverUrl=[[NSMutableString alloc]initWithString:@ServerUrl];
    [Str_serverUrl appendString:@"/CreateUser"];
    NSURL *url=[NSURL URLWithString:Str_serverUrl];
    ASIHTTPRequest *request=[ASIHTTPRequest requestWithURL:url];
    [request addRequestHeader:@"Content-Type" value:@"application/json; encoding=utf-8"];
    [request addRequestHeader:@"Accept" value:@"application/json"];
    [request setRequestMethod:@"POST"];
    [request setPostBody:multablejsondata];
    [request startSynchronous];
    NSError *requestError=[request error];
    if(!requestError){
        NSData *response = [request responseData];
        NSDictionary *data=[NSJSONSerialization JSONObjectWithData:response options:0 error:&error];
        self.WcfTestLable.text= [NSString stringWithFormat:@"%@",[data objectForKey:@"NewUserResult"]];
    }
}
-(void)Createuser{
    /*
     NSDictionary *user = [[NSDictionary alloc] initWithObjectsAndKeys:@"0", @"Version", nil];
     if ([NSJSONSerialization isValidJSONObject:user])
     {
     NSError *error;
     NSData *jsonData = [NSJSONSerialization dataWithJSONObject:user options:NSJSONWritingPrettyPrinted error: &error];
     NSMutableData *tempJsonData = [NSMutableData dataWithData:jsonData];
     //NSLog(@"Register JSON:%@",[[NSString alloc] initWithData:tempJsonData encoding:NSUTF8StringEncoding]);
     
     NSURL *url = [NSURL URLWithString:@"http://42.96.140.61/lev_version.php"];
     ASIHTTPRequest *request = [ASIHTTPRequest requestWithURL:url];
     [request addRequestHeader:@"Content-Type" value:@"application/json; encoding=utf-8"];
     [request addRequestHeader:@"Accept" value:@"application/json"];
     [request setRequestMethod:@"POST"];
     [request setPostBody:tempJsonData];
     [request startSynchronous];
     NSError *error1 = [request error];
     if (!error1) {
     NSString *response = [request responseString];
     NSLog(@"Test：%@",response);
     }
     }
     */
    NSMutableDictionary *registerInfo=[[NSMutableDictionary alloc]init];
    [registerInfo setValue:@"Keith" forKey:@"name"];
    [registerInfo setValue:@"1" forKey:@"sex"];
    [registerInfo setValue:@"111966" forKey:@"Md5_password"];
    [registerInfo setValue:@"1" forKey:@"role"];
    [registerInfo setValue:@"xiooix@126.com" forKey:@"email"];
    [registerInfo setValue:@"15501025919" forKey:@"phoneNum"];
    NSError *error=nil;
    NSData *Jsondata=[NSJSONSerialization dataWithJSONObject:registerInfo options:NSJSONWritingPrettyPrinted error:&error];
    NSMutableData *multablejsondata=[NSMutableData dataWithData:Jsondata];
    NSMutableString *Str_serverUrl=[[NSMutableString alloc]initWithString:@ServerUrl];
    [Str_serverUrl appendString:@"/CreateUser"];
    NSURL *url=[NSURL URLWithString:Str_serverUrl];
    ASIHTTPRequest *request=[ASIHTTPRequest requestWithURL:url];
    [request addRequestHeader:@"Content-Type" value:@"application/json; encoding=utf-8"];
    [request addRequestHeader:@"Accept" value:@"application/json"];
    [request setRequestMethod:@"POST"];
    [request setPostBody:multablejsondata];
    [request startSynchronous];
    NSError *requestError=[request error];
    if(!requestError){
        NSData *response = [request responseData];
        NSDictionary *data=[NSJSONSerialization JSONObjectWithData:response options:0 error:&error];
        self.WcfTestLable.text=[data objectForKey:@"JSONDataResult"];
    }
    
 
}
@end

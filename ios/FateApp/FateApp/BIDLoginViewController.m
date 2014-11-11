//
//  BIDLoginViewController.m
//  FateApp
//
//  Created by fengxi on 14-11-1.
//  Copyright (c) 2014年 fengxi. All rights reserved.
//

#import "BIDLoginViewController.h"

@interface BIDLoginViewController ()

@end

@implementation BIDLoginViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

- (IBAction)btnLogin:(id)sender {
    NSMutableDictionary *loginfo=[[NSMutableDictionary alloc]init];
    loginfo=[NSMutableDictionary dictionaryWithObjectsAndKeys:self.Username.text,@"name",self.password.text,@"password", nil];
    
}
@end

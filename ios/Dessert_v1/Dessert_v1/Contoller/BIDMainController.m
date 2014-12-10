//
//  BIDMainController.m
//  Dessert_v1
//
//  Created by fengxi on 14-12-6.
//  Copyright (c) 2014年 KeithMorning. All rights reserved.
//

#import "BIDMainController.h"
#import "BIDCommeMeathod.h"
#import  "BIDCommcode.h"
#import "BIDAFNetWork.h"
#import "BIDMainFooterView.h"
#import "BIDMainHeaderView.h"
#import "BIDMainTableViewCell.h"
@implementation BIDMainController

- (IBAction)LogOff:(id)sender {
    [self dismissViewControllerAnimated:YES completion:nil];
}
-(void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    //self.tableView.tableFooterView=
}
-(void)viewDidLoad{
    [self setTtileName];
    [self GetUserIDByNet];
}
-(void)GetUserIDByNet{
    if (thisUser==nil) {
        thisUser=[[BIDUser alloc]init];
    }
   
        NSString *urlstring=[[NSString alloc]initWithFormat:@"%@%@%@",@ServerUrl,Url_GetUserID,thisUser.username];
        [BIDAFNetWork GetDataFromNet:urlstring success:^(NSDictionary *resultDic) {
            NSString *userid=[resultDic objectForKey:@"GetUserIDResult"];
            NSLog(@"userid is %@",userid);
            thisUser.user_id=userid;
        } failure:^(NSError *error) {
            NSLog(@"%@",error);
        }];
    
    
}
-(void)setTtileName{
    NSString *username=[BIDCommeMeathod getuserName];
   [self setTitle:username];
    if (thisUser==nil) {
        thisUser=[[BIDUser alloc]init];
    }
    thisUser.username=username;
}
-(void)setTitle:(NSString *)title{
    self.navigationController.title=[[NSString alloc]initWithFormat:@"欢迎%@",title];
    NSLog(@"welcome %@",title);
}
#pragma tableviewDelegate
#pragma 
/*section count*/
-(NSInteger)numberOfSectionsInTableView:(UITableView *)tableView{
    return 1;
}
/*row count*/
-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{
    return 3;
}
/*cell */
-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath{
    static NSString *cellIndetifier=@"MaincellIndetifiler";
    BIDMainTableViewCell *cell=[tableView dequeueReusableCellWithIdentifier:cellIndetifier];
    if (cell==nil) {
        cell=[[BIDMainTableViewCell alloc]initItentifier:cellIndetifier];
    }
    cell.Username.text=@"keith";
    cell.PosterContent.text=[[NSString alloc]initWithFormat:@"%ld",(long)indexPath.row];
    return cell;
    
    
    return cell;
}
@end

//
//  BIDMainController.h
//  Dessert_v1
//
//  Created by fengxi on 14-12-6.
//  Copyright (c) 2014年 KeithMorning. All rights reserved.
//
#define Url_GetUserID @"GetUserID/"
#import <UIKit/UIKit.h>
#import "BIDUser.h"
//extern BIDUser *thisUser;
@interface BIDMainController : UITableViewController<UITableViewDelegate,UITableViewDataSource>
{
    BIDUser *thisUser;
}
//@property(nonatomic,strong)BIDUser *thisUser;
@property (strong, nonatomic) IBOutlet UITableView *MainTableView;
- (IBAction)LogOff:(id)sender;
@end

USE "FMS";

CREATE TABLE f_farmer (
  f_id        INT  NOT NULL IDENTITY(1, 1),
  f_firstname TEXT NOT NULL,
  f_lastname  TEXT NOT NULL,
  f_address   TEXT NOT NULL,
  PRIMARY KEY CLUSTERED (f_id ASC)
);

CREATE TABLE pr_product (
  pr_id    INT  NOT NULL IDENTITY(1, 1),
  pr_type  TEXT NOT NULL,
  pr_class INT  NULL,
  PRIMARY KEY CLUSTERED (pr_id ASC)
);

CREATE TABLE a_animal (
  a_id             INT  NOT NULL IDENTITY(1, 1),
  a_animal         TEXT NULL,
  a_age            REAL NOT NULL,
  a_weight         REAL NOT NULL,
  a_classification INT  NOT NULL,
  f_farmer_f_id    INT  NOT NULL,
  a_pr_product     INT  NULL,
  PRIMARY KEY CLUSTERED (a_id ASC),
  CONSTRAINT fk_a_animal_f_farmer1
  FOREIGN KEY (f_farmer_f_id)
  REFERENCES f_farmer (f_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_a_animal_pr_product1
  FOREIGN KEY (a_pr_product)
  REFERENCES pr_product (pr_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE c_corn (
  c_id         INT  NOT NULL IDENTITY(1, 1),
  c_type       TEXT NOT NULL,
  c_class      INT  NULL,
  c_dour       INT  NOT NULL,
  c_pr_product INT  NULL,
  PRIMARY KEY CLUSTERED (c_id ASC),
  CONSTRAINT fk_c_corn_pr_product1
  FOREIGN KEY (c_pr_product)
  REFERENCES pr_product (pr_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE p_property (
  p_id          INT  NOT NULL IDENTITY(1, 1),
  p_name        TEXT NOT NULL,
  p_description TEXT NULL,
  p_f_farmer    INT  NOT NULL,
  p_area        REAL NOT NULL,
  p_c_corn      INT  NULL,
  PRIMARY KEY CLUSTERED (p_id ASC),

  CONSTRAINT fk_p_property_f_farmer1
  FOREIGN KEY (p_f_farmer)
  REFERENCES f_farmer (f_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_p_property_c_corn1
  FOREIGN KEY (p_c_corn)
  REFERENCES c_corn (c_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE cf_farmer_has_corn (
  cf_f_farmer INT NOT NULL,
  cf_c_corn   INT NOT NULL,
  PRIMARY KEY (cf_f_farmer, cf_c_corn),
  CONSTRAINT fk_f_farmer_has_c_corn_f_farmer1
  FOREIGN KEY (cf_f_farmer)
  REFERENCES f_farmer (f_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_f_farmer_has_c_corn_c_corn1
  FOREIGN KEY (cf_c_corn)
  REFERENCES c_corn (c_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE cu_customer (
  cu_id        INT  NOT NULL IDENTITY(1, 1),
  cu_lastname  TEXT NOT NULL,
  cu_firstname TEXT NOT NULL,
  cu_address   TEXT NULL,
  PRIMARY KEY CLUSTERED (cu_id ASC)
);

CREATE TABLE fpr_farmer_sells_product (
  fpr_f_farmer      INT  NOT NULL,
  fpr_pr_product    INT  NOT NULL,
  fpr_price         REAL NOT NULL,
  cu_customer_cu_id INT  NOT NULL,
  PRIMARY KEY (fpr_f_farmer, fpr_pr_product),
  CONSTRAINT fk_f_farmer_has_pr_product_f_farmer1
  FOREIGN KEY (fpr_f_farmer)
  REFERENCES f_farmer (f_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_f_farmer_has_pr_product_pr_product1
  FOREIGN KEY (fpr_pr_product)
  REFERENCES pr_product (pr_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_fpr_farmer_sells_product_cu_customer1
  FOREIGN KEY (cu_customer_cu_id)
  REFERENCES cu_customer (cu_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);